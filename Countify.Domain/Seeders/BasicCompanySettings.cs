using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicCompanySettings
{
    public static readonly CompanySettings Default = new()
    {
        Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
        FiscalYear = DateTime.UtcNow.Year,
        UseDepartments = true,
        UseProjects = true
    };

    public static CompanySettings[] Items { get; } = [Default];
}