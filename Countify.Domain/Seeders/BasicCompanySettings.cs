using Countify.Domain.Entities.Accounting;

namespace Countify.Domain.Seeders;

public static class BasicCompanySettings
{
    public static readonly CompanySettings Default = new()
    {
        Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
        FiscalYear = DateTime.UtcNow.Year,
        DefaultProjectId = Guid.Parse("40000000-0000-0000-0000-000000000002"),
        DefaultDepartmentId = Guid.Parse("60000000-0000-0000-0000-000000000002"),
        UseDepartments = true,
        RequireDepartments = true,
        UseProjects = true,
        RequireProjects = false,
        UseSubProjects = false,
        RequireSubProjects = false,
        UseConceptTypes = false,
        RequireConceptTypes = false
    };

    public static CompanySettings[] Items { get; } = [Default];
}
