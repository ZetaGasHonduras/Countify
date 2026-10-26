using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.Inventory;

namespace Countify.Domain.Entities.AccountsPayable;

/// <summary>
/// Documento (movimiento) de CxP. Corresponde a <c>CXPDocumentos</c> del sistema legacy.
/// Espejo de <c>AccountsReceivableDocument</c> en CxC.
/// Semántica (nombres invertidos del legacy conservados vía <see cref="PayableConceptType"/>):
/// <list type="bullet">
/// <item><description><c>Debit(1)</c> = compra/factura: aumenta el saldo por pagar; recibe
/// pagos y copia los datos fiscales del proveedor.</description></item>
/// <item><description><c>Credit(2)</c> = pago/abono: reduce el saldo; aplica contra facturas
/// mediante <see cref="Lines"/>.</description></item>
/// </list>
/// Total del documento = <see cref="Amount"/> + <see cref="Tax"/> (decisión §6.2 del roadmap).
/// </summary>
public class PayableDocument : BaseEntity
{
    public int DocumentNo { get; set; }
    public Guid SupplierId { get; set; }
    public Supplier? Supplier { get; set; }
    public Guid ConceptId { get; set; }
    public PayableConcept? Concept { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string? Reference { get; set; }
    public string? AppliesTo { get; set; }
    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public Guid? ProjectId { get; set; }
    public Project? Project { get; set; }
    public Guid CurrencyId { get; set; }
    public Currency? Currency { get; set; }
    public decimal ExchangeRate { get; set; } = 1;
    public decimal Amount { get; set; }

    /// <summary>Impuesto sobre el monto (legacy: Impuesto). Total = Amount + Tax.</summary>
    public decimal Tax { get; set; }

    /// <summary>Impuesto en moneda local (legacy: ImpuestoLocal). Calculado: Tax * ExchangeRate.</summary>
    public decimal TaxLocal { get; set; }

    public string? Notes { get; set; }
    public bool IsVoided { get; set; }

    // --- Snapshot del proveedor (histórico, §3.6 del roadmap) ---
    public string? SupplierRegistration { get; set; }
    public string? SupplierAddress { get; set; }

    // --- Datos fiscales copiados del SupplierFiscalData activo del proveedor (compras) ---
    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public string? Correlative { get; set; }
    public DateTime? EmissionLimitDate { get; set; }

    public Guid? JournalEntryId { get; set; }
    public JournalEntry? JournalEntry { get; set; }

    // --- Ingreso de Compras (FASE 6 Etapa 5) ---
    /// <summary>
    /// Documento de compra que además ingresa mercancía al almacén: genera (o enlaza)
    /// un <see cref="InventoryMovement"/> 'COM' cuya suma de líneas alimenta
    /// <see cref="Amount"/>/<see cref="Tax"/>. Espejo del "Ingreso de Compras" de CXPDocumentosPadre.
    /// </summary>
    public bool IsPurchaseEntry { get; set; }

    public Guid? WarehouseId { get; set; }
    public Warehouse? Warehouse { get; set; }

    /// <summary>Movimiento de inventario 'COM' generado/actualizado por este documento.</summary>
    public Guid? InventoryMovementId { get; set; }
    public InventoryMovement? InventoryMovement { get; set; }

    public ICollection<PayableDocumentLine> Lines { get; set; } = new List<PayableDocumentLine>();
    public ICollection<PayableDocumentAttachment> Attachments { get; set; } = new List<PayableDocumentAttachment>();
}
