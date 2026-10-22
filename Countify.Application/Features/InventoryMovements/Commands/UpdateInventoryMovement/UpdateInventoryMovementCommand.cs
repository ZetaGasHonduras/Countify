using AutoMapper;
using Countify.Application.Features.InventoryMovements.Commands.CreateInventoryMovement;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryMovements.Commands.UpdateInventoryMovement;

public class UpdateInventoryMovementCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? Reference { get; set; }
    public string Concept { get; set; } = string.Empty;
    public string? Observations { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid? ToWarehouseId { get; set; }
    public Guid? DepartmentId { get; set; }
    public bool IsTaxExempt { get; set; }
    public List<InventoryMovementLineInput> Lines { get; set; } = [];
}

public class UpdateInventoryMovementCommandValidator : AbstractValidator<UpdateInventoryMovementCommand>
{
    public UpdateInventoryMovementCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.WarehouseId).NotEmpty();
        RuleFor(x => x.Concept).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Lines).NotEmpty().WithMessage("El movimiento debe tener al menos una línea.");

        RuleForEach(x => x.Lines).ChildRules(line =>
        {
            line.RuleFor(l => l.ProductId).NotEmpty();
            line.RuleFor(l => l.LocationId).NotEmpty();
            line.RuleFor(l => l.Quantity).GreaterThan(0);
            line.RuleFor(l => l.UnitCost).GreaterThanOrEqualTo(0);
            line.RuleFor(l => l.TaxRate).InclusiveBetween(0, 100);
        });
    }
}

public class UpdateInventoryMovementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateInventoryMovementCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        UpdateInventoryMovementCommand request, CancellationToken cancellationToken)
    {
        var movement = await unitOfWork.InventoryMovements.Query()
            .Include(m => m.Lines)
            .Include(m => m.Type)
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (movement is null)
            return Response<bool>.NotFound($"Movimiento de inventario {request.Id} no encontrado.");

        if (movement.IsVoided)
            return Response<bool>.Failure("El movimiento está anulado y no puede modificarse.");

        // Legacy: la solicitud consumida por un AJ- quedaba congelada (Appearance).
        if (movement.Type?.Code == "TP-")
        {
            var consumed = await unitOfWork.InventoryMovements.ExistsAsync(
                m => m.SourceRequestId == movement.Id && !m.IsVoided && m.Type!.Code == "AJ-",
                cancellationToken);
            if (consumed)
                return Response<bool>.Failure("La solicitud ya fue consumida por un ajuste negativo.");
        }

        var period = await unitOfWork.AccountingPeriods.Query()
            .FirstOrDefaultAsync(
                p => p.Month.Month == request.Date.Month && p.Month.Year == request.Date.Year,
                cancellationToken);
        if (period is null || period.IsClosed)
            return Response<bool>.Failure($"No existe un período contable abierto para {request.Date:MM/yyyy}.");

        var warehouse = await unitOfWork.Warehouses.GetByIdAsync(request.WarehouseId, cancellationToken);
        if (warehouse is null || warehouse.IsInactive)
            return Response<bool>.Failure("El almacén no existe o está inactivo.");

        // El tipo y la solicitud de origen son inmutables (definen el correlativo y el flujo).
        movement.Date = request.Date;
        movement.Reference = request.Reference?.Trim();
        movement.Concept = request.Concept.Trim();
        movement.Observations = request.Observations?.Trim();
        movement.WarehouseId = request.WarehouseId;
        movement.ToWarehouseId = movement.Type?.Code == "TP-" ? request.ToWarehouseId : null;
        movement.DepartmentId = movement.Type?.Code == "TP-" ? request.DepartmentId : movement.DepartmentId;
        movement.IsTaxExempt = request.IsTaxExempt;

        // Reemplazo de líneas.
        foreach (var oldLine in movement.Lines.ToList())
            await unitOfWork.InventoryMovementLines.DeleteAsync(oldLine, cancellationToken);

        var lines = mapper.Map<List<InventoryMovementLine>>(request.Lines);
        var order = 1;
        foreach (var line in lines)
            line.Order = order++;

        var productIds = lines.Select(l => l.ProductId).Distinct().ToList();
        var products = await unitOfWork.Products.Query()
            .Where(p => productIds.Contains(p.Id)).ToListAsync(cancellationToken);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line.Description))
            {
                var product = products.FirstOrDefault(p => p.Id == line.ProductId);
                if (product is null)
                    return Response<bool>.Failure("Un producto de las líneas no existe.");
                line.Description = product.Name;
            }
        }

        if (lines.Count > 999)
            return Response<bool>.Failure("El movimiento no puede tener más de 999 líneas.");

        // Validación de ubicaciones y regla de existencia (reintegro del efecto propio en salidas).
        var locationIds = lines.Select(l => l.LocationId).Distinct().ToList();
        var locations = await unitOfWork.Locations.Query()
            .Where(l => locationIds.Contains(l.Id)).ToListAsync(cancellationToken);

        foreach (var line in lines)
        {
            var location = locations.FirstOrDefault(l => l.Id == line.LocationId);
            if (location is null || location.IsInactive)
                return Response<bool>.Failure("Una de las ubicaciones no existe o está inactiva.");
            if (location.WarehouseId != request.WarehouseId)
                return Response<bool>.Failure($"La ubicación {location.Code} no pertenece al almacén seleccionado.");
        }

        var type = movement.Type!;
        if (type.ChecksStock && type.Direction == InventoryMovementDirection.Exit)
        {
            var stock = await StockCalculator.GetStockMapAsync(unitOfWork, cancellationToken);

            // El mapa incluye las líneas viejas de ESTE movimiento (salidas): se reintegran.
            var ownContribution = movement.Lines
                .GroupBy(l => (l.ProductId, l.LocationId))
                .ToDictionary(g => g.Key, g => g.Sum(l => l.Quantity));

            foreach (var line in lines)
            {
                var onHand = StockCalculator.GetOnHand(stock, line.ProductId, line.LocationId);
                if (ownContribution.TryGetValue((line.ProductId, line.LocationId), out var own))
                    onHand += own;

                var location = locations.First(l => l.Id == line.LocationId);
                if (line.Quantity > onHand && !location.ManageNegativeStock)
                    return Response<bool>.Failure(
                        $"No hay suficiente existencia en la ubicación {location.Code} " +
                        $"(disponible {onHand:N3}, solicitado {line.Quantity:N3}).");
            }
        }

        movement.Lines = lines;
        InventoryMovementTotals.Apply(movement);

        if (type.GeneratesPosting)
        {
            var settings = await unitOfWork.CompanySettings.Query().FirstOrDefaultAsync(cancellationToken);
            if (settings is null)
                return Response<bool>.Failure("Configure la información de la empresa primero.");

            var postingError = await InventoryPostingFactory.CreateOrUpdatePostingAsync(
                unitOfWork, movement, settings, cancellationToken);
            if (postingError is not null)
                return Response<bool>.Failure(postingError);
        }

        await unitOfWork.InventoryMovements.UpdateAsync(movement, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
