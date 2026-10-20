using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class SupplierPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewSuppliers = nameof(CanViewSuppliers);
    internal const string CanCreateSuppliers = nameof(CanCreateSuppliers);
    internal const string CanEditSuppliers = nameof(CanEditSuppliers);
    internal const string CanDeleteSuppliers = nameof(CanDeleteSuppliers);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewSuppliers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewSuppliers)));
        options.AddPolicy(CanCreateSuppliers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateSuppliers)));
        options.AddPolicy(CanEditSuppliers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditSuppliers)));
        options.AddPolicy(CanDeleteSuppliers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteSuppliers)));
    }
}
