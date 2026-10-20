using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class SupplierTypePolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewSupplierTypes = nameof(CanViewSupplierTypes);
    internal const string CanCreateSupplierTypes = nameof(CanCreateSupplierTypes);
    internal const string CanEditSupplierTypes = nameof(CanEditSupplierTypes);
    internal const string CanDeleteSupplierTypes = nameof(CanDeleteSupplierTypes);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewSupplierTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewSupplierTypes)));
        options.AddPolicy(CanCreateSupplierTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateSupplierTypes)));
        options.AddPolicy(CanEditSupplierTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditSupplierTypes)));
        options.AddPolicy(CanDeleteSupplierTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteSupplierTypes)));
    }
}
