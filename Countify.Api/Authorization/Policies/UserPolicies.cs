using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

public class UserPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanCreateUsers = nameof(CanCreateUsers);
    internal const string CanEditUsers = nameof(CanEditUsers);
    internal const string CanDeleteUsers = nameof(CanDeleteUsers);
    internal const string CanViewUsers = nameof(CanViewUsers);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanCreateUsers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateUsers)));
        options.AddPolicy(CanEditUsers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditUsers)));
        options.AddPolicy(CanDeleteUsers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteUsers)));
        options.AddPolicy(CanViewUsers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewUsers)));
    }
}