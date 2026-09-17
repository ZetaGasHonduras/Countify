using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;

internal sealed class DepartmentPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string CanViewDepartments = nameof(CanViewDepartments);
    internal const string CanCreateDepartments = nameof(CanCreateDepartments);
    internal const string CanEditDepartments = nameof(CanEditDepartments);
    internal const string CanDeleteDepartments = nameof(CanDeleteDepartments);

    public void Configure(AuthorizationOptions options)
    {
        options.AddPolicy(CanViewDepartments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanViewDepartments)));
        options.AddPolicy(CanCreateDepartments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanCreateDepartments)));
        options.AddPolicy(CanEditDepartments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanEditDepartments)));
        options.AddPolicy(CanDeleteDepartments,
            p => p.AddRequirements(new UserRoleHasPermissionRequirement(Permissions.CanDeleteDepartments)));
    }
}