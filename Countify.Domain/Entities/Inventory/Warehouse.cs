using Countify.Domain.Common;

namespace Countify.Domain.Entities.Inventory;

/// <summary>
/// Almacén. Corresponde a <c>Almacenes</c> del sistema legacy
/// (se omiten los flags sin uso real: SV y el duplicado Negativo —
/// los negativos se manejan por ubicación, como el legacy).
/// </summary>
public class Warehouse : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
    public bool IsInactive { get; set; }

    public ICollection<Location> Locations { get; set; } = new List<Location>();
}
