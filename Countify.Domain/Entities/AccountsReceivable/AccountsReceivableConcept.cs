using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Entities.AccountsReceivable;

public enum AccountsReceivableConceptType
{
    Debit = 1,
    Credit = 2
}

public class AccountsReceivableConcept : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public AccountsReceivableConceptType Type { get; set; } = AccountsReceivableConceptType.Debit;
    public Guid? AccountId { get; set; }
    public Account? Account { get; set; }
    public bool IsInactive { get; set; }
    public bool GeneratePosting { get; set; }
    public bool IsReceipt { get; set; }
    public string? Observations { get; set; }
}