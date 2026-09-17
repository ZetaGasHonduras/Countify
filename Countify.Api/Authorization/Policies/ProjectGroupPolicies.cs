using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class ProjectGroupPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewProjectGroups = nameof(CanViewProjectGroups);
    internal const string CanCreateProjectGroups = nameof(CanCreateProjectGroups);
    internal const string CanEditProjectGroups = nameof(CanEditProjectGroups);
    internal const string CanDeleteProjectGroups = nameof(CanDeleteProjectGroups);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewProjectGroups,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewProjectGroups)));
        options.AddPolicy(CanCreateProjectGroups,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateProjectGroups)));
        options.AddPolicy(CanEditProjectGroups,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditProjectGroups)));
        options.AddPolicy(CanDeleteProjectGroups,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteProjectGroups)));
    }
}