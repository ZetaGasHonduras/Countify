using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Entities.Inventory;

/// <summary>
/// Ubicación física dentro de un almacén. Corresponde a <c>Ubicaciones</c> del
/// sistema legacy. Las existencias se derivan por producto × ubicación.
/// </summary>
public class Location : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public Guid WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }

    /// <summary>Cuenta contable propia de la ubicación (legacy: CtaContable).</summary>
    public Guid? AccountId { get; set; }
    public Account? Account { get; set; }

    public Guid? ProjectId { get; set; }
    public Project? Project { get; set; }

    /// <summary>Permite salidas que dejan la existencia en negativo (legacy).</summary>
    public bool ManageNegativeStock { get; set; }

    /// <summary>Ubicación sugerida por defecto al capturar movimientos (legacy: PredeterminarParaMovimientos).</summary>
    public bool IsDefault { get; set; }

    public bool IsInactive { get; set; }

    public string? Observations { get; set; }
}
