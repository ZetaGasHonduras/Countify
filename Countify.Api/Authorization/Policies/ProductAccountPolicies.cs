using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class ProductAccountPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewProductAccounts = nameof(CanViewProductAccounts);
    internal const string CanCreateProductAccounts = nameof(CanCreateProductAccounts);
    internal const string CanEditProductAccounts = nameof(CanEditProductAccounts);
    internal const string CanDeleteProductAccounts = nameof(CanDeleteProductAccounts);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewProductAccounts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewProductAccounts)));
        options.AddPolicy(CanCreateProductAccounts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateProductAccounts)));
        options.AddPolicy(CanEditProductAccounts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditProductAccounts)));
        options.AddPolicy(CanDeleteProductAccounts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteProductAccounts)));
    }
}