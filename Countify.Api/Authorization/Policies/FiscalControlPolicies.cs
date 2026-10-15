using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class FiscalControlPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewFiscalControls = nameof(CanViewFiscalControls);
    internal const string CanCreateFiscalControls = nameof(CanCreateFiscalControls);
    internal const string CanEditFiscalControls = nameof(CanEditFiscalControls);
    internal const string CanDeleteFiscalControls = nameof(CanDeleteFiscalControls);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewFiscalControls,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewFiscalControls)));
        options.AddPolicy(CanCreateFiscalControls,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateFiscalControls)));
        options.AddPolicy(CanEditFiscalControls,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditFiscalControls)));
        options.AddPolicy(CanDeleteFiscalControls,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteFiscalControls)));
    }
}
