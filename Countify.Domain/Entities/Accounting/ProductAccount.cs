using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class ProductAccount : BaseEntity
{
    public Guid AccountId { get; set; }
    public Account? Account { get; set; }
    public Guid ProductId { get; set; }
}