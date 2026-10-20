using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class PayableConceptPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewPayableConcepts = nameof(CanViewPayableConcepts);
    internal const string CanCreatePayableConcepts = nameof(CanCreatePayableConcepts);
    internal const string CanEditPayableConcepts = nameof(CanEditPayableConcepts);
    internal const string CanDeletePayableConcepts = nameof(CanDeletePayableConcepts);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewPayableConcepts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewPayableConcepts)));
        options.AddPolicy(CanCreatePayableConcepts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreatePayableConcepts)));
        options.AddPolicy(CanEditPayableConcepts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditPayableConcepts)));
        options.AddPolicy(CanDeletePayableConcepts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeletePayableConcepts)));
    }
}
