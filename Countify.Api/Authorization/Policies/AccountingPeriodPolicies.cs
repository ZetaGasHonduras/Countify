using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class AccountingPeriodPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewAccountingPeriods = nameof(CanViewAccountingPeriods);
    internal const string CanCreateAccountingPeriods = nameof(CanCreateAccountingPeriods);
    internal const string CanEditAccountingPeriods = nameof(CanEditAccountingPeriods);
    internal const string CanDeleteAccountingPeriods = nameof(CanDeleteAccountingPeriods);
    internal const string CanCloseAccountingPeriods = nameof(CanCloseAccountingPeriods);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewAccountingPeriods,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewAccountingPeriods)));
        options.AddPolicy(CanCreateAccountingPeriods,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateAccountingPeriods)));
        options.AddPolicy(CanEditAccountingPeriods,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditAccountingPeriods)));
        options.AddPolicy(CanDeleteAccountingPeriods,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteAccountingPeriods)));
        options.AddPolicy(CanCloseAccountingPeriods,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCloseAccountingPeriods)));
    }
}