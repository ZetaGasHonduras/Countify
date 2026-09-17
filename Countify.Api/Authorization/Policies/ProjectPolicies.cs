using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class ProjectPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewProjects = nameof(CanViewProjects);
    internal const string CanCreateProjects = nameof(CanCreateProjects);
    internal const string CanEditProjects = nameof(CanEditProjects);
    internal const string CanDeleteProjects = nameof(CanDeleteProjects);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewProjects,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewProjects)));
        options.AddPolicy(CanCreateProjects,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateProjects)));
        options.AddPolicy(CanEditProjects,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditProjects)));
        options.AddPolicy(CanDeleteProjects,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteProjects)));
    }
}