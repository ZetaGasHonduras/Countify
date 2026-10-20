namespace Countify.Domain.Entities.Billing;

/// <summary>
/// Forma de pago de la factura. Conserva los valores del legacy
/// (<c>PublicEnums.PagoFactura { Contado = 1, Credito = 2 }</c>).
/// Solo las facturas a <see cref="Credito"/> generan su documento en Cuentas por Cobrar.
/// </summary>
public enum InvoicePaymentTerms
{
    Contado = 1,
    Credito = 2
}
