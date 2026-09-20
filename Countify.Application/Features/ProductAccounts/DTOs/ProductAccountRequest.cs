namespace Countify.Application.Features.ProductAccounts.DTOs;

public class ProductAccountRequest
{
    public Guid ProductId { get; set; }
    public Guid? QualityId { get; set; }
    public Guid InventoryAccountId { get; set; }
    public Guid IncomeAccountId { get; set; }
    public Guid CostAccountId { get; set; }
}