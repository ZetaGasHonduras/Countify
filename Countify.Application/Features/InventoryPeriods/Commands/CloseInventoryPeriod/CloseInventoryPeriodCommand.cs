using Countify.Application.Wrappers;
using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryPeriods.Commands.CloseInventoryPeriod;

/// <summary>
/// Legacy <c>PeriodosInventarios.ActCerrarPeriodo</c> + sp <c>PRDProductosCostosHistoricos</c>:
/// toma la foto del promedio ponderado de cada producto hasta el corte.
/// </summary>
public class CloseInventoryPeriodCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
}

public class CloseInventoryPeriodCommandValidator : AbstractValidator<CloseInventoryPeriodCommand>
{
    public CloseInventoryPeriodCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

public class CloseInventoryPeriodCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CloseInventoryPeriodCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(
        CloseInventoryPeriodCommand request, CancellationToken cancellationToken)
    {
        var period = await unitOfWork.InventoryPeriods.GetByIdAsync(request.Id, cancellationToken);
        if (period is null)
            return Response<bool>.NotFound($"Período de inventario {request.Id} no encontrado.");

        if (period.IsClosed)
            return Response<bool>.Failure("El período ya está cerrado; reábralo para recalcular.");

        var averages = await WeightedAverageCostCalculator.ComputeThroughAsync(
            unitOfWork, period.PeriodTo, cancellationToken);

        if (averages.Count == 0)
            return Response<bool>.Failure(
                "No hay movimientos de inventario contabilizables hasta el corte; no hay costos que fotografiar.");

        var productIds = averages.Keys.ToList();
        var products = await unitOfWork.Products.Query()
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync(cancellationToken);

        // Re-cierre: la foto anterior se reemplaza.
        var existing = await unitOfWork.ProductCostHistories.Query()
            .Where(c => c.InventoryPeriodId == period.Id)
            .ToListAsync(cancellationToken);
        foreach (var old in existing)
            await unitOfWork.ProductCostHistories.DeleteAsync(old, cancellationToken);

        foreach (var (productId, cost) in averages)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product is null) continue;

            await unitOfWork.ProductCostHistories.AddAsync(new ProductCostHistory
            {
                InventoryPeriodId = period.Id,
                ProductId = productId,
                ProductCode = product.Code,
                ProductName = product.Name,
                Date = period.PeriodTo,
                Cost = cost,
            }, cancellationToken);
        }

        period.IsClosed = true;
        period.ClosedAt = DateTime.UtcNow;

        await unitOfWork.InventoryPeriods.UpdateAsync(period, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true, 204);
    }
}
