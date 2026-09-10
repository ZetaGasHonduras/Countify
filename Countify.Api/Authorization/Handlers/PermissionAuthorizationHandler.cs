using System.Security.Claims;
using Countify.Api.Authorization.Requirements;
using Countify.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Countify.Api.Authorization.Handlers;

public sealed class PermissionAuthorizationHandler(IPermissionService permissionService)
    : AuthorizationHandler<UserRoleHasPermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        UserRoleHasPermissionRequirement requirement)
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId is null)
        {
            context.Fail();
            return;
        }

        var permissions = await permissionService.GetPermissionsAsync(userId);

        if (permissions.Contains(requirement.Permission.Name))
            context.Succeed(requirement);
        else
            context.Fail();
    }
}