using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class JournalEntryPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewJournalEntries = nameof(CanViewJournalEntries);
    internal const string CanCreateJournalEntries = nameof(CanCreateJournalEntries);
    internal const string CanEditJournalEntries = nameof(CanEditJournalEntries);
    internal const string CanDeleteJournalEntries = nameof(CanDeleteJournalEntries);
    internal const string CanVoidJournalEntries = nameof(CanVoidJournalEntries);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewJournalEntries,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewJournalEntries)));
        options.AddPolicy(CanCreateJournalEntries,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateJournalEntries)));
        options.AddPolicy(CanEditJournalEntries,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditJournalEntries)));
        options.AddPolicy(CanDeleteJournalEntries,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteJournalEntries)));
        options.AddPolicy(CanVoidJournalEntries,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanVoidJournalEntries)));
    }
}
