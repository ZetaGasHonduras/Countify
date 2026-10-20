using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class InvoicePolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewInvoices = nameof(CanViewInvoices);
    internal const string CanCreateInvoices = nameof(CanCreateInvoices);
    internal const string CanEditInvoices = nameof(CanEditInvoices);
    internal const string CanVoidInvoices = nameof(CanVoidInvoices);
    internal const string CanManageInvoicePayments = nameof(CanManageInvoicePayments);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewInvoices,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewInvoices)));
        options.AddPolicy(CanCreateInvoices,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateInvoices)));
        options.AddPolicy(CanEditInvoices,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditInvoices)));
        options.AddPolicy(CanVoidInvoices,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanVoidInvoices)));
        options.AddPolicy(CanManageInvoicePayments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanManageInvoicePayments)));
    }
}
