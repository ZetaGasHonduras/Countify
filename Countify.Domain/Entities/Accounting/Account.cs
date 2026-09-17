using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class Account : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsOperable { get; set; }
    public string? ParentCode { get; set; }
    public int Level { get; set; }
    public string? BudgetLine { get; set; }
    public bool BudgetControlled { get; set; }
    public bool IsAuxCxc { get; set; }
    public bool IsAuxCxp { get; set; }
    public bool IsAuxLoan { get; set; }
    public bool IsAuxAsset { get; set; }
    public bool IsBankAccount { get; set; }
}