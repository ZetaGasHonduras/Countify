using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class PaymentMethodPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewPaymentMethods = nameof(CanViewPaymentMethods);
    internal const string CanCreatePaymentMethods = nameof(CanCreatePaymentMethods);
    internal const string CanEditPaymentMethods = nameof(CanEditPaymentMethods);
    internal const string CanDeletePaymentMethods = nameof(CanDeletePaymentMethods);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewPaymentMethods,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewPaymentMethods)));
        options.AddPolicy(CanCreatePaymentMethods,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreatePaymentMethods)));
        options.AddPolicy(CanEditPaymentMethods,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditPaymentMethods)));
        options.AddPolicy(CanDeletePaymentMethods,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeletePaymentMethods)));
    }
}
