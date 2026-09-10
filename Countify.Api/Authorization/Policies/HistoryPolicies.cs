using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

public class HistoryPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewHistorie = nameof(CanViewHistorie);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewHistorie,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewHistorie)));
    }
}