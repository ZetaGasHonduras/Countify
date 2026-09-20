using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class BankTransactionType : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string MovementType { get; set; } = string.Empty;
    public string TransactionType { get; set; } = string.Empty;
}
