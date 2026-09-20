using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicBudgets
{
    public static readonly Budget Operating = new()
    {
        Id = Guid.Parse("70000000-0000-0000-0000-000000000001"),
        FiscalYear = 2026,
        Name = "Presupuesto Operativo 2026",
        Lines =
        [
            NewLine("70000000-0000-0000-0000-000000000101", BasicAccounts.OperatingExpenses.Id, BasicDepartments.Operations.Id, BasicProjects.Central.Id, 15000m),
            NewLine("70000000-0000-0000-0000-000000000102", BasicAccounts.ServiceRevenue.Id, BasicDepartments.Sales.Id, BasicProjects.Central.Id, 25000m),
            NewLine("70000000-0000-0000-0000-000000000103", BasicAccounts.CostOfSales.Id, BasicDepartments.Operations.Id, BasicProjects.WithoutGroup.Id, 10000m)
        ]
    };

    public static Budget[] Items { get; } = [Operating];

    private static BudgetLine NewLine(string id, Guid accountId, Guid departmentId, Guid projectId, decimal monthlyAmount) => new()
    {
        Id = Guid.Parse(id), AccountId = accountId, DepartmentId = departmentId, ProjectId = projectId,
        January = monthlyAmount, February = monthlyAmount, March = monthlyAmount, April = monthlyAmount,
        May = monthlyAmount, June = monthlyAmount, July = monthlyAmount, August = monthlyAmount,
        September = monthlyAmount, October = monthlyAmount, November = monthlyAmount, December = monthlyAmount
    };
}
