using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class CompanySettingsPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewCompanySettings = nameof(CanViewCompanySettings);
    internal const string CanEditCompanySettings = nameof(CanEditCompanySettings);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewCompanySettings,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewCompanySettings)));
        options.AddPolicy(CanEditCompanySettings,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditCompanySettings)));
    }
}