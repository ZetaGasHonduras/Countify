using Countify.Domain.Entities.Auth;
using Microsoft.AspNetCore.Authorization;

namespace Countify.Api.Authorization.Requirements;

public sealed class UserRoleHasPermissionRequirement(Permission permission) : IAuthorizationRequirement
{
    public Permission Permission { get; } = permission;
}