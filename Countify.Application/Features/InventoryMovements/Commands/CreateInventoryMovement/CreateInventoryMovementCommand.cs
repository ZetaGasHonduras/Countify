using AutoMapper;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryMovements.Commands.CreateInventoryMovement;

public class InventoryMovementLineInput
{
    public Guid ProductId { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public Guid LocationId { get; set; }
    public decimal Quantity { get; set; } = 1;
    public decimal UnitCost { get; set; }
    public decimal TaxRate { get; set; } = 15;
}

public class CreateInventoryMovementCommand : IRequest<Response<Guid>>
{
    public Guid TypeId { get; set; }
    public DateTime Date { get; set; }
    public string? Reference { get; set; }
    public string Concept { get; set; } = string.Empty;
    public string? Observations { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid? ToWarehouseId { get; set; }
    public Guid? DepartmentId { get; set; }
    public bool IsTaxExempt { get; set; }

    /// <summary>Ajuste negativo originado en una solicitud (TP−). Sus líneas se copian si no se envían.</summary>
    public Guid? SourceRequestId { get; set; }

    public List<InventoryMovementLineInput> Lines { get; set; } = [];
}

public class CreateInventoryMovementCommandValidator : AbstractValidator<CreateInventoryMovementCommand>
{
    public CreateInventoryMovementCommandValidator()
    {
        RuleFor(x => x.TypeId).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.WarehouseId).NotEmpty();
        RuleFor(x => x.Concept).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Reference).MaximumLength(100);
        RuleFor(x => x.Observations).MaximumLength(1000);
        RuleFor(x => x.Lines).NotEmpty().WithMessage("El movimiento debe tener al menos una línea.");

        RuleForEach(x => x.Lines).ChildRules(line =>
        {
            line.RuleFor(l => l.ProductId).NotEmpty();
            line.RuleFor(l => l.LocationId).NotEmpty();
            line.RuleFor(l => l.Quantity).GreaterThan(0);
            line.RuleFor(l => l.UnitCost).GreaterThanOrEqualTo(0);
            line.RuleFor(l => l.TaxRate).InclusiveBetween(0, 100);
            line.RuleFor(l => l.Description).MaximumLength(300);
        });
    }
}

public class CreateInventoryMovementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateInventoryMovementCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(
        CreateInventoryMovementCommand request, CancellationToken cancellationToken)
    {
        var type = await unitOfWork.InventoryMovementTypes.GetByIdAsync(request.TypeId, cancellationToken);
        if (type is null || type.IsInactive)
            return Response<Guid>.Failure("El tipo de movimiento no existe o está inactivo.");

        if (type.Code == "COM")
            return Response<Guid>.Failure("Los ingresos de compra se registran desde Cuentas por Pagar.");

        var warehouse = await unitOfWork.Warehouses.GetByIdAsync(request.WarehouseId, cancellationToken);
        if (warehouse is null || warehouse.IsInactive)
            return Response<Guid>.Failure("El almacén no existe o está inactivo.");

        var isRequest = type.Code == "TP-";

        if (isRequest)
        {
            if (request.ToWarehouseId is not Guid toWarehouseId)
                return Response<Guid>.Failure("La solicitud debe indicar el almacén destino.");

            if (toWarehouseId == request.WarehouseId)
                return Response<Guid>.Failure("El almacén origen y destino de la solicitud no pueden ser el mismo.");

            if (!await unitOfWork.Warehouses.ExistsAsync(
                    w => w.Id == toWarehouseId && !w.IsInactive, cancellationToken))
                return Response<Guid>.Failure("El almacén destino no existe o está inactivo.");

            if (request.DepartmentId is null)
                return Response<Guid>.Failure("La solicitud debe indicar el departamento.");
        }

        // Período contable abierto (CierrePeriodo del legacy).
        var period = await unitOfWork.AccountingPeriods.Query()
            .FirstOrDefaultAsync(
                p => p.Month.Month == request.Date.Month && p.Month.Year == request.Date.Year,
                cancellationToken);
        if (period is null || period.IsClosed)
            return Response<Guid>.Failure($"No existe un período contable abierto para {request.Date:MM/yyyy}.");

        InventoryMovement movement;
        List<InventoryMovementLine> lines;

        if (request.SourceRequestId is Guid requestId)
        {
            if (type.Code != "AJ-")
                return Response<Guid>.Failure("Solo un ajuste negativo puede originarse en una solicitud.");

            var response = await CreateFromRequestAsync(requestId, type, request, warehouse, cancellationToken);
            if (response.Error is not null)
                return Response<Guid>.Failure(response.Error);

            movement = response.Movement;
            lines = response.Lines;
        }
        else
        {
            movement = mapper.Map<InventoryMovement>(request);
            movement.Code = null;
            movement.IsVoided = false;

            lines = mapper.Map<List<InventoryMovementLine>>(request.Lines);
            var order = 1;
            foreach (var line in lines)
                line.Order = order++;

            // Snapshot de descripción desde el catálogo (legacy: copiaba Producto.Descripcion).
            var productIds = lines.Where(l => string.IsNullOrWhiteSpace(l.Description))
                .Select(l => l.ProductId).Distinct().ToList();
            var products = await unitOfWork.Products.Query()
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync(cancellationToken);
            foreach (var line in lines.Where(l => string.IsNullOrWhiteSpace(l.Description)))
            {
                var product = products.FirstOrDefault(p => p.Id == line.ProductId);
                if (product is null)
                    return Response<Guid>.Failure("Un producto de las líneas no existe.");
                line.Description = product.Name;
            }
        }

        var lineError = await ValidateLinesAsync(movement, lines, warehouse.Id, type, cancellationToken);
        if (lineError is not null)
            return Response<Guid>.Failure(lineError);

        movement.Lines = lines;

        InventoryMovementTotals.Apply(movement);

        var maxCorrelativo = await unitOfWork.InventoryMovements.Query()
            .Where(m => m.TypeId == type.Id)
            .Select(m => (int?)m.Correlativo).MaxAsync(cancellationToken);
        movement.Correlativo = (maxCorrelativo ?? 0) + 1;
        movement.Code = $"{type.Code}{movement.Correlativo:D10}";

        await unitOfWork.InventoryMovements.AddAsync(movement, cancellationToken);

        if (type.GeneratesPosting)
        {
            var settings = await unitOfWork.CompanySettings.Query()
                .FirstOrDefaultAsync(cancellationToken);
            if (settings is null)
                return Response<Guid>.Failure("Configure la información de la empresa primero.");

            var postingError = await InventoryPostingFactory.CreateOrUpdatePostingAsync(
                unitOfWork, movement, settings, cancellationToken);
            if (postingError is not null)
                return Response<Guid>.Failure(postingError);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(movement.Id, 201);
    }

    private async Task<(InventoryMovement Movement, List<InventoryMovementLine> Lines, string? Error)> CreateFromRequestAsync(
        Guid requestId,
        InventoryMovementType type,
        CreateInventoryMovementCommand request,
        Warehouse warehouse,
        CancellationToken cancellationToken)
    {
        var movement = await unitOfWork.InventoryMovements.Query()
            .Include(m => m.Lines)
            .Include(m => m.Type)
            .FirstOrDefaultAsync(m => m.Id == requestId, cancellationToken);

        if (movement is null)
            return (default!, [], "La solicitud de origen no existe.");

        if (movement.Type?.Code != "TP-")
            return (default!, [], "El documento de origen no es una solicitud.");

        if (movement.IsVoided)
            return (default!, [], "La solicitud de origen está anulada.");

        if (await unitOfWork.InventoryMovements.ExistsAsync(
                m => m.SourceRequestId == movement.Id && !m.IsVoided && m.Type!.Code == "AJ-", cancellationToken))
            return (default!, [], "La solicitud ya fue consumida por un ajuste negativo.");

        var adjustment = new InventoryMovement
        {
            TypeId = type.Id,
            Type = null,
            Date = movement.Date,
            Reference = request.Reference?.Trim(),
            Concept = string.IsNullOrWhiteSpace(request.Concept) ? movement.Concept : request.Concept.Trim(),
            Observations = request.Observations?.Trim(),
            WarehouseId = movement.WarehouseId,
            DepartmentId = movement.DepartmentId,
            IsTaxExempt = movement.IsTaxExempt,
            SourceRequestId = movement.Id,
        };

        // El legacy copiaba fecha/concepto y todas las líneas de la solicitud.
        var lines = movement.Lines.Select(l => new InventoryMovementLine
        {
            Order = l.Order,
            ProductId = l.ProductId,
            Description = l.Description,
            Unit = l.Unit,
            LocationId = l.LocationId,
            Quantity = l.Quantity,
            UnitCost = l.UnitCost,
            TaxRate = l.TaxRate,
        }).ToList();

        if (lines.Count == 0)
            return (default!, [], "La solicitud de origen no tiene líneas.");

        return (adjustment, lines, null);
    }

    private async Task<string?> ValidateLinesAsync(
        InventoryMovement movement,
        List<InventoryMovementLine> lines,
        Guid warehouseId,
        InventoryMovementType type,
        CancellationToken cancellationToken)
    {
        if (lines.Count == 0)
            return "El movimiento debe tener al menos una línea.";

        if (lines.Count > 999)
            return "El movimiento no puede tener más de 999 líneas.";

        var locationIds = lines.Select(l => l.LocationId).Distinct().ToList();
        var locations = await unitOfWork.Locations.Query()
            .Include(l => l.Warehouse)
            .Where(l => locationIds.Contains(l.Id))
            .ToListAsync(cancellationToken);

        foreach (var line in lines)
        {
            var location = locations.FirstOrDefault(l => l.Id == line.LocationId);
            if (location is null || location.IsInactive)
                return "Una de las ubicaciones no existe o está inactiva.";

            if (location.WarehouseId != warehouseId)
                return $"La ubicación {location.Code} no pertenece al almacén {movement.Warehouse?.Name ?? "seleccionado"}.";
        }

        // Regla de existencia del legacy: salidas con ChecksStock no pueden agotar la existencia
        // salvo ubicación que permite negativos. (Autoritativa aquí, no en el front.)
        if (type.ChecksStock && type.Direction == InventoryMovementDirection.Exit)
        {
            var stock = await StockCalculator.GetStockMapAsync(unitOfWork, cancellationToken);

            foreach (var line in lines)
            {
                var onHand = StockCalculator.GetOnHand(stock, line.ProductId, line.LocationId);
                var location = locations.First(l => l.Id == line.LocationId);

                if (line.Quantity > onHand && !location.ManageNegativeStock)
                    return $"No hay suficiente existencia para el producto en la ubicación {location.Code} " +
                           $"(disponible {onHand:N3}, solicitado {line.Quantity:N3}).";
            }
        }

        return null;
    }
}
