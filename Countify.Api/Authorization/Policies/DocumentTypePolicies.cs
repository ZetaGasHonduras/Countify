using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class DocumentTypePolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewDocumentTypes = nameof(CanViewDocumentTypes);
    internal const string CanCreateDocumentTypes = nameof(CanCreateDocumentTypes);
    internal const string CanEditDocumentTypes = nameof(CanEditDocumentTypes);
    internal const string CanDeleteDocumentTypes = nameof(CanDeleteDocumentTypes);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewDocumentTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewDocumentTypes)));
        options.AddPolicy(CanCreateDocumentTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateDocumentTypes)));
        options.AddPolicy(CanEditDocumentTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditDocumentTypes)));
        options.AddPolicy(CanDeleteDocumentTypes,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteDocumentTypes)));
    }
}