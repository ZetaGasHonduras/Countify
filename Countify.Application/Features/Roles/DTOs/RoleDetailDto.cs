namespace Countify.Application.Features.Roles.DTOs;

public class RoleDetailDto : RoleDto
{
    public IList<PermissionDto> Permissions { get; set; } = [];
}