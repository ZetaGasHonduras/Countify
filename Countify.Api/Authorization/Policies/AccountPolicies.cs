using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class AccountPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewAccounts = nameof(CanViewAccounts);
    internal const string CanCreateAccounts = nameof(CanCreateAccounts);
    internal const string CanEditAccounts = nameof(CanEditAccounts);
    internal const string CanDeleteAccounts = nameof(CanDeleteAccounts);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewAccounts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewAccounts)));
        options.AddPolicy(CanCreateAccounts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateAccounts)));
        options.AddPolicy(CanEditAccounts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditAccounts)));
        options.AddPolicy(CanDeleteAccounts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteAccounts)));
    }
}