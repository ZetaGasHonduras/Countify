using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class PosCatalogPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewCashRegisters = nameof(CanViewCashRegisters);
    internal const string CanCreateCashRegisters = nameof(CanCreateCashRegisters);
    internal const string CanEditCashRegisters = nameof(CanEditCashRegisters);
    internal const string CanDeleteCashRegisters = nameof(CanDeleteCashRegisters);
    internal const string CanViewCashiers = nameof(CanViewCashiers);
    internal const string CanCreateCashiers = nameof(CanCreateCashiers);
    internal const string CanEditCashiers = nameof(CanEditCashiers);
    internal const string CanDeleteCashiers = nameof(CanDeleteCashiers);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewCashRegisters,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewCashRegisters)));
        options.AddPolicy(CanCreateCashRegisters,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateCashRegisters)));
        options.AddPolicy(CanEditCashRegisters,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditCashRegisters)));
        options.AddPolicy(CanDeleteCashRegisters,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteCashRegisters)));

        options.AddPolicy(CanViewCashiers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewCashiers)));
        options.AddPolicy(CanCreateCashiers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateCashiers)));
        options.AddPolicy(CanEditCashiers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditCashiers)));
        options.AddPolicy(CanDeleteCashiers,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteCashiers)));
    }
}
