using Countify.Domain.Common;

namespace Countify.Domain.Entities.Billing;

/// <summary>
/// Método de pago. Corresponde a <c>MetodosDePago</c> del sistema legacy
/// ( FacturaComercial → pagos con cuadre exacto ).
/// </summary>
public class PaymentMethod : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsInactive { get; set; }
    public bool IsDefault { get; set; }
}
