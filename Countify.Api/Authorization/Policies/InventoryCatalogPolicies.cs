using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class InventoryCatalogPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewWarehouses = nameof(CanViewWarehouses);
    internal const string CanCreateWarehouses = nameof(CanCreateWarehouses);
    internal const string CanEditWarehouses = nameof(CanEditWarehouses);
    internal const string CanDeleteWarehouses = nameof(CanDeleteWarehouses);
    internal const string CanViewLocations = nameof(CanViewLocations);
    internal const string CanCreateLocations = nameof(CanCreateLocations);
    internal const string CanEditLocations = nameof(CanEditLocations);
    internal const string CanDeleteLocations = nameof(CanDeleteLocations);
    internal const string CanViewInventoryMovementTypes = nameof(CanViewInventoryMovementTypes);
    internal const string CanCreateInventoryMovementTypes = nameof(CanCreateInventoryMovementTypes);
    internal const string CanEditInventoryMovementTypes = nameof(CanEditInventoryMovementTypes);
    internal const string CanDeleteInventoryMovementTypes = nameof(CanDeleteInventoryMovementTypes);
    internal const string CanViewInventoryMovements = nameof(CanViewInventoryMovements);
    internal const string CanCreateInventoryMovements = nameof(CanCreateInventoryMovements);
    internal const string CanEditInventoryMovements = nameof(CanEditInventoryMovements);
    internal const string CanVoidInventoryMovements = nameof(CanVoidInventoryMovements);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewWarehouses,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewWarehouses)));
        options.AddPolicy(CanCreateWarehouses,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateWarehouses)));
        options.AddPolicy(CanEditWarehouses,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditWarehouses)));
        options.AddPolicy(CanDeleteWarehouses,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteWarehouses)));

        options.AddPolicy(CanViewLocations,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewLocations)));
        options.AddPolicy(CanCreateLocations,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateLocations)));
        options.AddPolicy(CanEditLocations,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditLocations)));
        options.AddPolicy(CanDeleteLocations,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteLocations)));

        options.AddPolicy(CanViewInventoryMovementTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewInventoryMovementTypes)));
        options.AddPolicy(CanCreateInventoryMovementTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateInventoryMovementTypes)));
        options.AddPolicy(CanEditInventoryMovementTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditInventoryMovementTypes)));
        options.AddPolicy(CanDeleteInventoryMovementTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteInventoryMovementTypes)));

        options.AddPolicy(CanViewInventoryMovements,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewInventoryMovements)));
        options.AddPolicy(CanCreateInventoryMovements,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateInventoryMovements)));
        options.AddPolicy(CanEditInventoryMovements,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditInventoryMovements)));
        options.AddPolicy(CanVoidInventoryMovements,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanVoidInventoryMovements)));
    }
}
