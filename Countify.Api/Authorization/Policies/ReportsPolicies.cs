using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class ReportsPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewReports = nameof(CanViewReports);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewReports,
            policy => policy.AddRequirements(
                new UserRoleHasPermissionRequirement(Permissions.CanViewReports)));
    }
}
