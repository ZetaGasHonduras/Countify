namespace Countify.Application.Features.Projects.DTOs;

public class ProjectGroupDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
}