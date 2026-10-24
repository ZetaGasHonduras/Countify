using Countify.Domain.Common;

namespace Countify.Domain.Entities.Inventory;

/// <summary>
/// Período de inventarios. Corresponde a <c>PeriodosInventarios</c> del legacy:
/// su cierre (<c>ActCerrarPeriodo</c> + sp <c>PRDProductosCostosHistoricos</c>)
/// toma la foto del costo promedio ponderado de cada producto. Como en el viejo,
/// NO bloquea movimientos (eso lo hace el período contable); es bitácora + costeo.
/// </summary>
public class InventoryPeriod : BaseEntity
{
    /// <summary>Primer día del mes (único).</summary>
    public DateTime Month { get; set; }

    public DateTime PeriodFrom { get; set; }
    public DateTime PeriodTo { get; set; }

    public bool IsClosed { get; set; }
    public DateTime? ClosedAt { get; set; }

    public string? Notes { get; set; }
}
