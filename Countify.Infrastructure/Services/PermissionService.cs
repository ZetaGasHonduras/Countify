using Countify.Application.Common.Interfaces;
using Countify.Domain.Entities.Auth;
using Countify.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quick.AutoInject.Services;

namespace Countify.Infrastructure.Services;

[ScopeService]
public sealed class PermissionService(
    UserManager<ApplicationUser> userManager,
    CountifyDbContext context) : IPermissionService
{
    public async Task<HashSet<string>> GetPermissionsAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user is null) return [];

        var roles = await userManager.GetRolesAsync(user);

        return await context.RolePermissions
            .Where(rp => roles.Contains(rp.Role!.Name!))
            .Select(rp => rp.Permission!.Name)
            .ToHashSetAsync();
    }
}