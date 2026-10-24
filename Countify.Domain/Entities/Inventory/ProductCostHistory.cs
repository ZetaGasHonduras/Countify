using Countify.Domain.Common;

namespace Countify.Domain.Entities.Inventory;

/// <summary>
/// Foto del costo promedio ponderado de un producto al cierre del período
/// (legacy <c>ProductosCostoHistorico</c>: Costo con 4 decimales, descripción
/// snapshot, fecha = Hasta del período).
/// </summary>
public class ProductCostHistory : BaseEntity
{
    public Guid InventoryPeriodId { get; set; }
    public InventoryPeriod? InventoryPeriod { get; set; }

    public Guid ProductId { get; set; }

    /// <summary>Snapshot del catálogo (legacy guardaba el int plano + descripción).</summary>
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    /// <summary>Promedio ponderado (4 decimales, como el legacy).</summary>
    public decimal Cost { get; set; }
}
