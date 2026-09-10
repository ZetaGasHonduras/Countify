using Microsoft.AspNetCore.Identity;

namespace Countify.Domain.Entities.Auth;

public sealed class RolePermission
{
    public string RoleId { get; set; } = null!;
    public IdentityRole? Role { get; set; }
    public int PermissionId { get; set; }
    public Permission? Permission { get; set; }
}