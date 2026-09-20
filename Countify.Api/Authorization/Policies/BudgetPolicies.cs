using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class BudgetPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewBudgets = nameof(CanViewBudgets);
    internal const string CanCreateBudgets = nameof(CanCreateBudgets);
    internal const string CanEditBudgets = nameof(CanEditBudgets);
    internal const string CanDeleteBudgets = nameof(CanDeleteBudgets);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewBudgets, p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewBudgets)));
        options.AddPolicy(CanCreateBudgets, p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateBudgets)));
        options.AddPolicy(CanEditBudgets, p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditBudgets)));
        options.AddPolicy(CanDeleteBudgets, p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteBudgets)));
    }
}
