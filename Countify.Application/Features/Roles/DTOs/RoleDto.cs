namespace Countify.Application.Features.Roles.DTOs;

public class RoleDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int PermissionCount { get; set; }
}