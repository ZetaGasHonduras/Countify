using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryMovements;

/// <summary>
/// Existencias derivadas (espejo de <c>VSTExistenciasUbicaciones</c> del legacy):
/// Σ entradas − Σ salidas de movimientos vigentes cuyo tipo <c>CountsForStock</c>.
/// Las anuladas quedan fuera del cálculo.
/// </summary>
internal static class StockCalculator
{
    public record struct StockKey(Guid ProductId, Guid LocationId);

    public static async Task<Dictionary<StockKey, decimal>> GetStockMapAsync(
        IUnitOfWork unitOfWork, CancellationToken cancellationToken)
    {
        var lines = await unitOfWork.InventoryMovementLines.Query()
            .Include(l => l.Movement!.Type)
            .Where(l => l.Movement != null && !l.Movement.IsVoided && l.Movement.Type!.CountsForStock)
            .ToListAsync(cancellationToken);

        var map = new Dictionary<StockKey, decimal>();
        foreach (var line in lines)
        {
            var key = new StockKey(line.ProductId, line.LocationId);
            var signed = line.Movement!.Type!.Direction == InventoryMovementDirection.Entry
                ? line.Quantity
                : -line.Quantity;

            map.TryGetValue(key, out var current);
            map[key] = current + signed;
        }

        return map;
    }

    public static decimal GetOnHand(IReadOnlyDictionary<StockKey, decimal> map, Guid productId, Guid locationId)
        => map.TryGetValue(new StockKey(productId, locationId), out var value) ? value : 0m;
}
