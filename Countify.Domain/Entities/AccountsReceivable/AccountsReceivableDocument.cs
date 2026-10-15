using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Enums;

namespace Countify.Domain.Entities.AccountsReceivable;

public class AccountsReceivableDocument : BaseEntity
{
    public int DocumentNo { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public Guid ConceptId { get; set; }
    public AccountsReceivableConcept? Concept { get; set; }
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
    public string? Notes { get; set; }
    public bool IsVoided { get; set; }
    public int? ReceiptNumber { get; set; }

    /// <summary>Indica si el correlativo del recibo ya fue asignado (legacy: CorrelativoAsignado).</summary>
    public bool ReceiptNumberAssigned { get; set; }

    public Guid? JournalEntryId { get; set; }
    public JournalEntry? JournalEntry { get; set; }

    // --- Datos fiscales (aplican a Notas de Crédito y Débito) ---

    public Guid? FiscalControlId { get; set; }
    public FiscalControl? FiscalControl { get; set; }

    /// <summary>Número de la nota (legacy: NumeroDeNotaDeCreditos / NumeroDeNotaDebito).</summary>
    public string? NoteNumber { get; set; }

    /// <summary>CAI del documento que se afecta, normalmente la factura (legacy: CAIFactura).</summary>
    public string? InvoiceCAI { get; set; }

    /// <summary>CAI propio de la nota.</summary>
    public string? CAI { get; set; }

    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public DateTime? EmissionDate { get; set; }
    public DateTime? EmissionLimitDate { get; set; }

    /// <summary>Motivo de la nota de crédito (legacy: MotivoNotaCredito).</summary>
    public CreditNoteReason? CreditNoteReason { get; set; }

    /// <summary>Concepto libre de la nota (legacy: Concepto).</summary>
    public string? FiscalConcept { get; set; }

    public ICollection<AccountsReceivableDocumentLine> Lines { get; set; } = new List<AccountsReceivableDocumentLine>();
    public ICollection<AccountsReceivableDocumentAttachment> Attachments { get; set; } = new List<AccountsReceivableDocumentAttachment>();
}
