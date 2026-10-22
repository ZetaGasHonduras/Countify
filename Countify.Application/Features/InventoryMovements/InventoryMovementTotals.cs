using Countify.Domain.Entities.Inventory;

namespace Countify.Application.Features.InventoryMovements;

/// <summary>
/// Motor de totales del movimiento (legacy <c>BaseInventarios.totalizar()</c>):
/// por línea, Base = Cantidad·Costo y Total = Base + Base·%ISV/100 redondeado.
/// Exenta a nivel documento fuerza ISV 0 sin alterar el % capturado.
/// </summary>
internal static class InventoryMovementTotals
{
    public static void Apply(InventoryMovement movement)
    {
        decimal subTotal = 0, taxAmount = 0, total = 0;

        foreach (var line in movement.Lines)
        {
            var baseAmount = Math.Round(line.Quantity * line.UnitCost, 2, MidpointRounding.AwayFromZero);
            var rate = movement.IsTaxExempt || !line.IsTaxable() ? 0m : line.TaxRate;
            var tax = Math.Round(baseAmount * rate / 100m, 2, MidpointRounding.AwayFromZero);

            line.TaxAmount = tax;
            line.LineTotal = Math.Round(baseAmount + tax, 2, MidpointRounding.AwayFromZero);

            subTotal += baseAmount;
            taxAmount += tax;
            total += line.LineTotal;
        }

        movement.SubTotal = Math.Round(subTotal, 2);
        movement.TaxAmount = Math.Round(taxAmount, 2);
        movement.Total = Math.Round(total, 2);
    }
}

internal static class InventoryMovementLineExtensions
{
    /// <summary>Tasa 0 implícita cuando no se captura %ISV (el legacy trataba 0 como no gravado).</summary>
    public static bool IsTaxable(this InventoryMovementLine line) => line.TaxRate > 0;
}
