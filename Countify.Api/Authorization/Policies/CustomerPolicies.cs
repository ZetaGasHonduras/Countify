using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class CustomerPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewCustomers = nameof(CanViewCustomers);
    internal const string CanCreateCustomers = nameof(CanCreateCustomers);
    internal const string CanEditCustomers = nameof(CanEditCustomers);
    internal const string CanDeleteCustomers = nameof(CanDeleteCustomers);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewCustomers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewCustomers)));
        options.AddPolicy(CanCreateCustomers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateCustomers)));
        options.AddPolicy(CanEditCustomers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditCustomers)));
        options.AddPolicy(CanDeleteCustomers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteCustomers)));
    }
}