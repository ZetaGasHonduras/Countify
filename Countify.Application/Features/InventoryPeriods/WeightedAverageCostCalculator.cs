using Countify.Domain.Entities.Inventory;
using Countify.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.InventoryPeriods;

/// <summary>
/// Promedio ponderado acumulado por producto (re-implementación en C# del sp
/// <c>PRDProductosCostosHistoricos</c>, no recuperable): se recorren los
/// movimientos contabilizables vigentes ordenados por fecha hasta el corte;
/// cada entrada repondera el promedio con su costo unitario (sin ISV),
/// las salidas consumen cantidad sin alterar el promedio.
/// </summary>
internal static class WeightedAverageCostCalculator
{
    public static async Task<Dictionary<Guid, decimal>> ComputeThroughAsync(
        IUnitOfWork unitOfWork, DateTime dateThrough, CancellationToken cancellationToken)
    {
        var lines = await unitOfWork.InventoryMovementLines.Query()
            .Include(l => l.Movement!.Type)
            .Where(l => l.Movement != null
                        && !l.Movement.IsVoided
                        && l.Movement.Type!.CountsForStock
                        && l.Movement.Type.Direction != InventoryMovementDirection.NoStock
                        && l.Movement.Date <= dateThrough.Date.AddDays(1).AddTicks(-1))
            .ToListAsync(cancellationToken);

        var history = lines
            .GroupBy(l => l.ProductId)
            .ToDictionary(
                g => g.Key,
                g => g.GroupBy(l => l.MovementId)
                      .Select(mg => new
                      {
                          Movement = mg.First().Movement!,
                          Quantity = mg.Sum(l => l.Quantity),
                          // Costo medio de la línea del movimiento, SIN ISV (el impuesto va a cuentas fiscales).
                          Cost = mg.Sum(l => l.Quantity * l.UnitCost) / mg.Sum(l => l.Quantity),
                      })
                      .OrderBy(x => x.Movement.Date).ThenBy(x => x.Movement.Code)
                      .ToList());

        var result = new Dictionary<Guid, decimal>();

        foreach (var (productId, movements) in history)
        {
            decimal qty = 0, avg = 0;

            foreach (var mv in movements)
            {
                if (mv.Movement.Type!.Direction == InventoryMovementDirection.Entry)
                {
                    // Reponderar solo con entradas que aportan valor.
                    var newQty = qty + mv.Quantity;
                    if (newQty > 0)
                        avg = (qty * avg + mv.Quantity * mv.Cost) / newQty;
                    qty = newQty;
                }
                else
                {
                    qty -= mv.Quantity;
                }
            }

            result[productId] = Math.Round(avg, 4, MidpointRounding.AwayFromZero);
        }

        return result;
    }
}
