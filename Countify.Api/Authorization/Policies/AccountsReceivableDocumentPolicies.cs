using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class AccountsReceivableDocumentPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewAccountsReceivableDocuments = nameof(CanViewAccountsReceivableDocuments);
    internal const string CanCreateAccountsReceivableDocuments = nameof(CanCreateAccountsReceivableDocuments);
    internal const string CanEditAccountsReceivableDocuments = nameof(CanEditAccountsReceivableDocuments);
    internal const string CanVoidAccountsReceivableDocuments = nameof(CanVoidAccountsReceivableDocuments);
    internal const string CanEditReceiptNumber = nameof(CanEditReceiptNumber);
    internal const string CanManageAccountsReceivableAttachments = nameof(CanManageAccountsReceivableAttachments);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewAccountsReceivableDocuments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewAccountsReceivableDocuments)));
        options.AddPolicy(CanCreateAccountsReceivableDocuments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateAccountsReceivableDocuments)));
        options.AddPolicy(CanEditAccountsReceivableDocuments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditAccountsReceivableDocuments)));
        options.AddPolicy(CanVoidAccountsReceivableDocuments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanVoidAccountsReceivableDocuments)));
        options.AddPolicy(CanEditReceiptNumber,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditReceiptNumber)));
        options.AddPolicy(CanManageAccountsReceivableAttachments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanManageAccountsReceivableAttachments)));
    }
}