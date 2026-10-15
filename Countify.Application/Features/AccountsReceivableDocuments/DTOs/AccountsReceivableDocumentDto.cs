using Countify.Domain.Enums;

namespace Countify.Application.Features.AccountsReceivableDocuments.DTOs;

public class AccountsReceivableDocumentDto
{
    public Guid Id { get; set; }
    public int DocumentNo { get; set; }
    public int? ReceiptNumber { get; set; }
    public bool ReceiptNumberAssigned { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerCode { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public Guid ConceptId { get; set; }
    public string ConceptDescription { get; set; } = string.Empty;
    public bool IsCredit { get; set; }
    public bool IsFiscalNote { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public string? Reference { get; set; }
    public string? AppliesTo { get; set; }
    public Guid? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public Guid? ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public Guid CurrencyId { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public decimal ExchangeRate { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountLocal { get; set; }
    public decimal OutstandingAmount { get; set; }
    public decimal DifferenceAmount { get; set; }
    public string? Notes { get; set; }
    public bool IsVoided { get; set; }

    // --- Datos fiscales (Notas de Crédito / Débito) ---

    public Guid? FiscalControlId { get; set; }
    public string? NoteNumber { get; set; }
    public string? InvoiceCAI { get; set; }
    public string? CAI { get; set; }
    public string? RangeFrom { get; set; }
    public string? RangeTo { get; set; }
    public DateTime? EmissionDate { get; set; }
    public DateTime? EmissionLimitDate { get; set; }
    public CreditNoteReason? CreditNoteReason { get; set; }
    public string? FiscalConcept { get; set; }

    public List<AccountsReceivableDocumentLineDto> Lines { get; set; } = [];
    public List<AccountsReceivableDocumentAttachmentDto> Attachments { get; set; } = [];
}

public class AccountsReceivableDocumentLineDto
{
    public Guid Id { get; set; }
    public Guid DocumentId { get; set; }
    public Guid AppliedDocumentId { get; set; }
    public string AppliedDocumentNo { get; set; } = string.Empty;
    public string? AppliedReference { get; set; }
    public string AppliedConcept { get; set; } = string.Empty;
    public DateTime AppliedDate { get; set; }
    public string AppliedCurrencyCode { get; set; } = string.Empty;
    public decimal AppliedAmount { get; set; }
    public decimal AppliedOutstandingAmount { get; set; }
    public decimal Amount { get; set; }
}
