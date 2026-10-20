using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class PayableDocumentPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewPayableDocuments = nameof(CanViewPayableDocuments);
    internal const string CanCreatePayableDocuments = nameof(CanCreatePayableDocuments);
    internal const string CanEditPayableDocuments = nameof(CanEditPayableDocuments);
    internal const string CanVoidPayableDocuments = nameof(CanVoidPayableDocuments);
    internal const string CanManagePayableAttachments = nameof(CanManagePayableAttachments);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewPayableDocuments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewPayableDocuments)));
        options.AddPolicy(CanCreatePayableDocuments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreatePayableDocuments)));
        options.AddPolicy(CanEditPayableDocuments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditPayableDocuments)));
        options.AddPolicy(CanVoidPayableDocuments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanVoidPayableDocuments)));
        options.AddPolicy(CanManagePayableAttachments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanManagePayableAttachments)));
    }
}
