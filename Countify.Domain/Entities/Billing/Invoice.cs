using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.AccountsReceivable;

namespace Countify.Domain.Entities.Billing;

/// <summary>
/// Factura comercial de cliente. Corresponde a <c>FacturaComercial</c> del sistema legacy
/// (la herencia <c>BaseFacturacion</c> se aplana aquí: solo se usa la familia Factura).
/// </summary>
public class Invoice : BaseEntity
{
    /// <summary>Número fiscal <c>Sucursal-Punto-Code-NNNNNNNN</c>. Se asigna una sola vez al primer guardado.</summary>
    public string? Number { get; set; }

    /// <summary>Correlativo interno numérico para ordenar el listado (legacy: Correlativo).</summary>
    public int Correlativo { get; set; }

    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public InvoicePaymentTerms PaymentTerms { get; set; } = InvoicePaymentTerms.Credito;

    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    /// <summary>Referencia / factura del cliente (legacy: Referencia).</summary>
    public string? Reference { get; set; }

    /// <summary>Orden de compra del cliente (legacy: OrdenDeCompra).</summary>
    public string? OrderNumber { get; set; }

    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public Guid? ProjectId { get; set; }
    public Project? Project { get; set; }

    public Guid CurrencyId { get; set; }
    public Currency? Currency { get; set; }
    public decimal ExchangeRate { get; set; } = 1;

    // --- Snapshot del cliente al emitir (histórico, como el legacy) ---
    public string CustomerName { get; set; } = string.Empty;
    public string? CustomerTaxId { get; set; }
    public string? CustomerAddress { get; set; }
    public string? CustomerPhone { get; set; }

    // --- Banderas fiscales del leguaje legacy ---
    /// <summary>Factura exenta: ISV = 0 en todas las líneas (legacy: Exento).</summary>
    public bool IsTaxExempt { get; set; }

    /// <summary>Cliente exonerado (legacy: Exonerada); mutuamente excluyente con <see cref="IsTaxExempt"/>.</summary>
    public bool IsExonerated { get; set; }

    // --- Totales calculados por InvoiceTotals (se persisten) ---
    /// <summary>Σ bases gravadas/exentas de las líneas (descuento aplicado, sin impuesto).</summary>
    public decimal SubTotal { get; set; }
    /// <summary>Σ impuestos de las líneas (legacy: Impuesto).</summary>
    public decimal TaxAmount { get; set; }
    /// <summary>Σ descuentos de las líneas (legacy: DescuentoTotal).</summary>
    public decimal DiscountTotal { get; set; }
    /// <summary>Base de líneas con ISV 0 cuando la factura es exenta/exonerada (legacy: SubTotalExento/Exonerado).</summary>
    public decimal SubTotalExempt { get; set; }
    /// <summary>Total = SubTotal + TaxAmount (legacy: Total).</summary>
    public decimal Total { get; set; }
    /// <summary>Total en moneda local = Total * ExchangeRate (legacy: TotalLocal).</summary>
    public decimal TotalLocal { get; set; }

    public string? Notes { get; set; }

    /// <summary>Guardado e impreso: congela la factura (legacy: Impreso).</summary>
    public bool IsPrinted { get; set; }
    public DateTime? PrintedAt { get; set; }

    public bool IsVoided { get; set; }
    public DateTime? VoidedAt { get; set; }
    public string? VoidReason { get; set; }

    // --- Control fiscal usado en la emisión (CAI, rangos) ---
    public Guid? FiscalControlId { get; set; }
    public FiscalControl? FiscalControl { get; set; }
    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public DateTime? EmissionLimitDate { get; set; }

    /// <summary>Documento CxC generado cuando <see cref="PaymentTerms"/> es Crédito.</summary>
    public Guid? ReceivableDocumentId { get; set; }
    public AccountsReceivableDocument? ReceivableDocument { get; set; }

    /// <summary>Lote de la partida de ventas mensual que contabilizó esta factura.</summary>
    public Guid? SalesBatchId { get; set; }
    public SalesJournalBatch? SalesBatch { get; set; }

    public ICollection<InvoiceLine> Lines { get; set; } = new List<InvoiceLine>();
}
