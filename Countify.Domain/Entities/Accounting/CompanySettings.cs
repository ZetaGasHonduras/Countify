using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class CompanySettings : BaseEntity
{
    public string CompanyName { get; set; } = string.Empty;
    public string TaxId { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
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
