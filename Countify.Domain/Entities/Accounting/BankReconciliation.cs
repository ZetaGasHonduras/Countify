using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class BankReconciliation : BaseEntity
{
    public Guid BankAccountId { get; set; }
    public BankAccount? BankAccount { get; set; }
    public DateTime ReconciliationDate { get; set; }
    public decimal StatementBalance { get; set; }
    public decimal BookBalance { get; set; }
    public bool IsClosed { get; set; }
    public string? Notes { get; set; }
    public List<BankTransaction> Transactions { get; set; } = [];
}
