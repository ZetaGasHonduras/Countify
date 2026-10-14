using Countify.Domain.Common;

namespace Countify.Domain.Entities.AccountsReceivable;

public class AccountsReceivableDocumentLine : BaseEntity
{
    public Guid DocumentId { get; set; }
    public AccountsReceivableDocument Document { get; set; } = null!;
    public Guid AppliedDocumentId { get; set; }
    public AccountsReceivableDocument AppliedDocument { get; set; } = null!;
    public decimal Amount { get; set; }
}