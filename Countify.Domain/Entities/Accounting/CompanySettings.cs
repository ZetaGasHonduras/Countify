using Countify.Domain.Common;

namespace Countify.Domain.Entities.Accounting;

public class CompanySettings : BaseEntity
{
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