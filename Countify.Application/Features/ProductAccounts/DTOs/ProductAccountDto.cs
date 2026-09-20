namespace Countify.Application.Features.ProductAccounts.DTOs;

public class ProductAccountDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public Guid? QualityId { get; set; }
    public string? QualityName { get; set; }
    public Guid InventoryAccountId { get; set; }
    public string InventoryAccountCode { get; set; } = string.Empty;
    public string InventoryAccountName { get; set; } = string.Empty;
    public Guid IncomeAccountId { get; set; }
    public string IncomeAccountCode { get; set; } = string.Empty;
    public string IncomeAccountName { get; set; } = string.Empty;
    public Guid CostAccountId { get; set; }
    public string CostAccountCode { get; set; } = string.Empty;
    public string CostAccountName { get; set; } = string.Empty;
}