using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class RolePolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanCreateRoles = nameof(CanCreateRoles);
    internal const string CanEditRoles = nameof(CanEditRoles);
    internal const string CanDeleteRoles = nameof(CanDeleteRoles);
    internal const string CanViewRoles = nameof(CanViewRoles);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanCreateRoles,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateRoles)));
        options.AddPolicy(CanEditRoles,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditRoles)));
        options.AddPolicy(CanDeleteRoles,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteRoles)));
        options.AddPolicy(CanViewRoles,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewRoles)));
    }
}