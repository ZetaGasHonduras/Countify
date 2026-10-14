using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class AccountsReceivableConceptPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewAccountsReceivableConcepts = nameof(CanViewAccountsReceivableConcepts);
    internal const string CanCreateAccountsReceivableConcepts = nameof(CanCreateAccountsReceivableConcepts);
    internal const string CanEditAccountsReceivableConcepts = nameof(CanEditAccountsReceivableConcepts);
    internal const string CanDeleteAccountsReceivableConcepts = nameof(CanDeleteAccountsReceivableConcepts);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewAccountsReceivableConcepts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewAccountsReceivableConcepts)));
        options.AddPolicy(CanCreateAccountsReceivableConcepts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateAccountsReceivableConcepts)));
        options.AddPolicy(CanEditAccountsReceivableConcepts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditAccountsReceivableConcepts)));
        options.AddPolicy(CanDeleteAccountsReceivableConcepts,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteAccountsReceivableConcepts)));
    }
}