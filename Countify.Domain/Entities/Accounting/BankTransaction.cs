using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class BankTransaction : BaseEntity
{
    public Guid BankAccountId { get; set; }
    public BankAccount? BankAccount { get; set; }
    public Guid TransactionTypeId { get; set; }
    public BankTransactionType? TransactionType { get; set; }
    public string TransactionTypeValue { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public Guid CurrencyId { get; set; }
    public Currency? Currency { get; set; }
    public decimal ExchangeRate { get; set; } = 1;
    public decimal Amount { get; set; }
    public decimal LocalAmount { get; set; }
    public string? Reference { get; set; }
    public string? Beneficiary { get; set; }
    public string? Concept { get; set; }
    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public Guid? ProjectId { get; set; }
    public Project? Project { get; set; }
    public bool Reconciled { get; set; }
    public bool Voided { get; set; }
    public Guid? JournalEntryId { get; set; }
    public JournalEntry? JournalEntry { get; set; }
    public Guid CounterpartAccountId { get; set; }
    public Account? CounterpartAccount { get; set; }
    public Guid? BankReconciliationId { get; set; }
    public BankReconciliation? BankReconciliation { get; set; }
}
