using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class CustomerTypePolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewCustomerTypes = nameof(CanViewCustomerTypes);
    internal const string CanCreateCustomerTypes = nameof(CanCreateCustomerTypes);
    internal const string CanEditCustomerTypes = nameof(CanEditCustomerTypes);
    internal const string CanDeleteCustomerTypes = nameof(CanDeleteCustomerTypes);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewCustomerTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewCustomerTypes)));
        options.AddPolicy(CanCreateCustomerTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateCustomerTypes)));
        options.AddPolicy(CanEditCustomerTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditCustomerTypes)));
        options.AddPolicy(CanDeleteCustomerTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteCustomerTypes)));
    }
}