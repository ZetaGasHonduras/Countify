using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class CompanySettings : BaseEntity
{
    // Subset of the legacy Controles singleton currently migrated for accounting.
    // Legacy Controles also contains payroll, inventory, billing and integration settings.
    public int FiscalYear { get; set; } = DateTime.UtcNow.Year;
    public Guid? DefaultProjectId { get; set; }
    public Project? DefaultProject { get; set; }
    public Guid? DefaultDepartmentId { get; set; }
    public Department? DefaultDepartment { get; set; }

    public bool UseDepartments { get; set; }
    public bool RequireDepartments { get; set; }
    public bool UseProjects { get; set; }
    public bool RequireProjects { get; set; }
    public bool UseSubProjects { get; set; }
    public bool RequireSubProjects { get; set; }
    public bool UseConceptTypes { get; set; }
    public bool RequireConceptTypes { get; set; }
}
