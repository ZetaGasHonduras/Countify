using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Entities.Billing;

/// <summary>
/// Línea de factura. Corresponde a <c>BaseFacturacionDetalles</c> del sistema legacy.
/// Total por línea = (Cantidad·Precio − Descuento) + (Cantidad·Precio − Descuento)·%ISV/100,
/// redondeado a 2 decimales (fórmula exacta de <c>totalizar()</c>).
/// </summary>
public class InvoiceLine : BaseEntity
{
    public Guid InvoiceId { get; set; }
    public Invoice? Invoice { get; set; }

    public int Order { get; set; }

    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }

    /// <summary>Código libre de la línea (legacy: Codigo). Se autocompleta desde el producto.</summary>
    public string? Code { get; set; }

    /// <summary>Descripción visible en el detalle de la factura.</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>Unidad de medida (legacy: Unidad). Texto libre como en el viejo.</summary>
    public string? Unit { get; set; }

    public decimal Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }

    /// <summary>Porcentaje de descuento de la línea (0-100, RuleRange del legacy).</summary>
    public decimal DiscountPercent { get; set; }
    /// <summary>Monto de descuento calculado sobre Cantidad·Precio.</summary>
    public decimal DiscountAmount { get; set; }

    /// <summary>Legacy: ISV (bool). Si es false, el porcentaje aplicado es 0.</summary>
    public bool IsTaxable { get; set; } = true;
    /// <summary>Porcentaje de ISV (legacy: %ISV). Default 15; 4/19/otros manuales.</summary>
    public decimal TaxRate { get; set; } = 15;

    /// <summary>Total de la línea, base + impuesto, redondeado (legacy: Total).</summary>
    public decimal LineTotal { get; set; }

    public string? Notes { get; set; }
}
