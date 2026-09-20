using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicProductAccounts
{
    public static readonly ProductAccount Services = New(
        "90000000-0000-0000-0000-000000000001",
        BasicProducts.Services.Id,
        null,
        BasicAccounts.CurrentAssets.Id,
        BasicAccounts.ServiceRevenue.Id,
        BasicAccounts.CostOfSales.Id);

    public static readonly ProductAccount OfficeSupplies = New(
        "90000000-0000-0000-0000-000000000002",
        BasicProducts.OfficeSupplies.Id,
        BasicQualities.Standard.Id,
        BasicAccounts.CurrentAssets.Id,
        BasicAccounts.ServiceRevenue.Id,
        BasicAccounts.CostOfSales.Id);

    public static readonly ProductAccount Equipment = New(
        "90000000-0000-0000-0000-000000000003",
        BasicProducts.Equipment.Id,
        BasicQualities.Premium.Id,
        BasicAccounts.FurnitureAndEquipment.Id,
        BasicAccounts.ServiceRevenue.Id,
        BasicAccounts.CostOfSales.Id);

    public static ProductAccount[] Items { get; } = [Services, OfficeSupplies, Equipment];

    private static ProductAccount New(
        string id,
        Guid productId,
        Guid? qualityId,
        Guid inventoryAccountId,
        Guid incomeAccountId,
        Guid costAccountId)
        => new()
        {
            Id = Guid.Parse(id),
            ProductId = productId,
            QualityId = qualityId,
            InventoryAccountId = inventoryAccountId,
            IncomeAccountId = incomeAccountId,
            CostAccountId = costAccountId
        };
}
