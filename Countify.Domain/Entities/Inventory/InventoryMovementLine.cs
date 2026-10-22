using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Entities.Inventory;

/// <summary>
/// Línea de movimiento. Corresponde a <c>BaseInventariosDetalles</c> del legacy:
/// Total = Cantidad·Costo + ISV (sobre costo, no sobre precio de venta).
/// La ubicación es el origen (salidas) o el destino (entradas) dentro del almacén.
/// </summary>
public class InventoryMovementLine : BaseEntity
{
    public Guid MovementId { get; set; }
    public InventoryMovement? Movement { get; set; }

    public int Order { get; set; }

    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    /// <summary>Descripción al momento (snapshot, como el legacy).</summary>
    public string Description { get; set; } = string.Empty;

    public string? Unit { get; set; }

    public Guid LocationId { get; set; }
    public Location? Location { get; set; }

    public decimal Quantity { get; set; } = 1;

    /// <summary>Costo unitario del producto en el movimiento (legacy: Costo).</summary>
    public decimal UnitCost { get; set; }

    /// <summary>%ISV sobre el costo (legacy: PorcentajeImpuesto, default 15).</summary>
    public decimal TaxRate { get; set; } = 15;

    public decimal TaxAmount { get; set; }

    /// <summary>Cantidad·Costo + Impuesto, redondeado por línea.</summary>
    public decimal LineTotal { get; set; }
}
