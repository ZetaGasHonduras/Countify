using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Entities.Inventory;

/// <summary>
/// Movimiento de inventario. Aplana <c>BaseInventarios</c> y sus derivados del
/// legacy (<c>INVAjustesPositivos</c> AJ+, <c>INVAjustesNegativos</c> AJ−,
/// <c>INVSolicitudes</c> TP−; 'COM' queda para el Ingreso de Compras de la Etapa 5).
/// </summary>
public class InventoryMovement : BaseEntity
{
    /// <summary>Prefijo del tipo + correlativo (legacy: Codigo). Se asigna una sola vez al guardar.</summary>
    public string? Code { get; set; }

    /// <summary>Correlativo interno por tipo (arregla el COUNT() duplicable del legacy).</summary>
    public int Correlativo { get; set; }

    public Guid TypeId { get; set; }
    public InventoryMovementType? Type { get; set; }

    public DateTime Date { get; set; }

    public string? Reference { get; set; }
    public string Concept { get; set; } = string.Empty;
    public string? Observations { get; set; }

    /// <summary>Almacén del movimiento (AJ+: destino; AJ−/TP−: origen).</summary>
    public Guid WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }

    /// <summary>Solo solicitudes (TP−): almacén destino de la petición.</summary>
    public Guid? ToWarehouseId { get; set; }
    public Warehouse? ToWarehouse { get; set; }

    /// <summary>Solo solicitudes: departamento que pide (legacy: INVDepartamentos → Department).</summary>
    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }

    /// <summary>Legacy: ExentaDeImpuestos — fuerza ISV 0 en las líneas.</summary>
    public bool IsTaxExempt { get; set; }

    // --- Totales calculados por InventoryMovementTotals (se persisten) ---
    public decimal SubTotal { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal Total { get; set; }

    /// <summary>Ajuste negativo originado en una solicitud (legacy: Solicitud + Utilizada).</summary>
    public Guid? SourceRequestId { get; set; }
    public InventoryMovement? SourceRequest { get; set; }

    /// <summary>Partida generada (tipos con GeneratesPosting). El legacy recreaba la partida en cada guardado.</summary>
    public Guid? JournalEntryId { get; set; }
    public JournalEntry? JournalEntry { get; set; }

    public bool IsVoided { get; set; }
    public DateTime? VoidedAt { get; set; }
    public string? VoidReason { get; set; }

    public ICollection<InventoryMovementLine> Lines { get; set; } = new List<InventoryMovementLine>();
}
