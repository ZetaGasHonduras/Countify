using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class ProductAccount : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public Guid? QualityId { get; set; }
    public Quality? Quality { get; set; }

    public Guid InventoryAccountId { get; set; }
    public Account? InventoryAccount { get; set; }

    public Guid IncomeAccountId { get; set; }
    public Account? IncomeAccount { get; set; }

    public Guid CostAccountId { get; set; }
    public Account? CostAccount { get; set; }
}