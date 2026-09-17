namespace Countify.Application.Features.Accounts.DTOs;

public class AccountDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
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
    public decimal TotalDebit { get; set; }
    public decimal TotalCredit { get; set; }
    public decimal Balance { get; set; }
}