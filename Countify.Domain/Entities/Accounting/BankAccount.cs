using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class BankAccount : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public Guid AccountingAccountId { get; set; }
    public Account? AccountingAccount { get; set; }
    public Guid CurrencyId { get; set; }
    public Currency? Currency { get; set; }
    public int? CutoffDay { get; set; }
    public string? CheckNumber { get; set; }
    public decimal Interest { get; set; }
    public decimal Balance { get; set; }
    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public Guid? ProjectId { get; set; }
    public Project? Project { get; set; }
    public bool IsInactive { get; set; }
    public string? DefaultNdNcText { get; set; }
}
