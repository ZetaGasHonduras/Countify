using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Entities.AccountsReceivable;

public class Customer : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid? CustomerTypeId { get; set; }
    public CustomerType? CustomerType { get; set; }
    public string? TaxId { get; set; }
    public string? IdentityDocument { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public int CreditDays { get; set; }
    public decimal CreditLimit { get; set; }
    public Guid? AccountingAccountId { get; set; }
    public Account? AccountingAccount { get; set; }
    public bool IsInactive { get; set; }
}