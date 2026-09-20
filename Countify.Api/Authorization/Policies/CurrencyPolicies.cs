using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class CurrencyPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string View = nameof(View); internal const string Create = nameof(Create); internal const string Edit = nameof(Edit); internal const string Delete = nameof(Delete);
    public void Configure(AuthorizationOptions options)
    {
        Add(options, View, Permissions.CanViewCurrencies); Add(options, Create, Permissions.CanCreateCurrencies);
        Add(options, Edit, Permissions.CanEditCurrencies); Add(options, Delete, Permissions.CanDeleteCurrencies);
    }
    private static void Add(AuthorizationOptions options, string name, Countify.Domain.Entities.Auth.Permission permission) => options.AddPolicy(name, p => p.AddRequirements(new UserRoleHasPermissionRequirement(permission)));
}
