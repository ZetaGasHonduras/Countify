using Countify.Domain.Common;

namespace Countify.Domain.Entities.Billing;

/// <summary>
/// Cajero (quién atiende la caja). Corresponde a <c>Cajeros</c> del legacy, del que
/// se elimina intencionalmente la <c>Clave</c> en texto plano: la identidad del
/// operador la da su <see cref="UserId"/> de la app (decisión de seguridad del roadmap).
/// </summary>
public class Cashier : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    /// <summary>Usuario de la app que opera como este cajero (opcional pero recomendado).
    /// Id string de <c>ApplicationUser</c> (Identity).</summary>
    public string? UserId { get; set; }

    public bool IsInactive { get; set; }
}
