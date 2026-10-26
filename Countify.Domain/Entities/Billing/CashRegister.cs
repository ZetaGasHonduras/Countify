using Countify.Domain.Common;

namespace Countify.Domain.Entities.Billing;

/// <summary>
/// Caja registradora (punto de venta físico). Corresponde a <c>Cajas</c> del
/// sistema legacy (código+nombre), con las banderas de catálogo modernas.
/// </summary>
public class CashRegister : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public bool IsInactive { get; set; }
}
