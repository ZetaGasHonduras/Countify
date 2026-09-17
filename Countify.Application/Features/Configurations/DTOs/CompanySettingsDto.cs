namespace Countify.Application.Features.Configurations.DTOs;

public class CompanySettingsDto
{
    public Guid Id { get; set; }
    public int FiscalYear { get; set; }
    public Guid? DefaultProjectId { get; set; }
    public Guid? DefaultDepartmentId { get; set; }
    public bool UseDepartments { get; set; }
    public bool RequireDepartments { get; set; }
    public bool UseProjects { get; set; }
    public bool RequireProjects { get; set; }
    public bool UseSubProjects { get; set; }
    public bool RequireSubProjects { get; set; }
    public bool UseConceptTypes { get; set; }
    public bool RequireConceptTypes { get; set; }
}