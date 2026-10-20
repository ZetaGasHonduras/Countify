using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class SalesJournalBatchPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewSalesJournalBatches = nameof(CanViewSalesJournalBatches);
    internal const string CanCreateSalesJournalBatches = nameof(CanCreateSalesJournalBatches);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewSalesJournalBatches,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewSalesJournalBatches)));
        options.AddPolicy(CanCreateSalesJournalBatches,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateSalesJournalBatches)));
    }
}
