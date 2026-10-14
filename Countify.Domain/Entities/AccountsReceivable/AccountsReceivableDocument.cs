using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

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
    public Guid? JournalEntryId { get; set; }
    public JournalEntry? JournalEntry { get; set; }
    public ICollection<AccountsReceivableDocumentLine> Lines { get; set; } = new List<AccountsReceivableDocumentLine>();
}