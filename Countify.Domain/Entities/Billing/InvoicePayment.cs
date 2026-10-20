using Countify.Domain.Common;

namespace Countify.Domain.Entities.Billing;

/// <summary>
/// Pago de una factura. Corresponde a <c>FacturaPagos</c> del sistema legacy:
/// método + monto, y la regla <c>"Debe Cuadrar"</c>: la suma de pagos debe
/// cuadrar exactamente con el Total de la factura.
/// </summary>
public class InvoicePayment : BaseEntity
{
    public Guid InvoiceId { get; set; }
    public Invoice? Invoice { get; set; }

    public Guid PaymentMethodId { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }

    /// <summary>Monto en la moneda de la factura (legacy: Monto).</summary>
    public decimal Amount { get; set; }
}
