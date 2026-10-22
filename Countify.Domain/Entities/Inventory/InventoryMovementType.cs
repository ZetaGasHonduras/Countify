using Countify.Domain.Common;

namespace Countify.Domain.Entities.Inventory;

/// <summary>
/// Tipo de movimiento de inventario. Corresponde a <c>BaseInventariosTipos</c>
/// del legacy (AJ+, AJ−, TP−, COM…). Los tipos de sistema (<see cref="IsSystem"/>)
/// no pueden eliminarse porque el flujo de Ingreso de Compras y las solicitudes dependen de ellos.
/// </summary>
public class InventoryMovementType : BaseEntity
{
    /// <summary>Prefijo del correlativo (legacy: Codigo, p.ej. "AJ+").</summary>
    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public InventoryMovementDirection Direction { get; set; } = InventoryMovementDirection.Entry;

    /// <summary>La salida valida existencia suficiente salvo ubicación con ManageNegativeStock.</summary>
    public bool ChecksStock { get; set; }

    /// <summary>Marca que genera partida contable al guardar (los AJ± del legacy la generaban; TP− no).</summary>
    public bool GeneratesPosting { get; set; }

    /// <summary>No borrable ni renombrable (AJ+/AJ−/TP−/COM).</summary>
    public bool IsSystem { get; set; }

    public bool IsInactive { get; set; }
}
