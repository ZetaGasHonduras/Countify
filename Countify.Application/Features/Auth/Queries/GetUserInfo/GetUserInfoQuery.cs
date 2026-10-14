using Countify.Application.Common.Interfaces;
using Countify.Application.Features.Auth.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Auth.Queries.GetUserInfo;

public record GetUserInfoQuery : IRequest<Response<UserInfoResponse>>;

public class GetUserInfoQueryHandler(
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IUnitOfWork unitOfWork,
    ICurrentUserService currentUserService)
    : IRequestHandler<GetUserInfoQuery, Response<UserInfoResponse>>
{
    public async Task<Response<UserInfoResponse>> Handle(
        GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var (userId, _) = currentUserService.GetCurrentUser();
        if (userId == Guid.Empty)
            return Response<UserInfoResponse>.Unauthorized();

        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            return Response<UserInfoResponse>.Unauthorized();

        if (!user.IsActive)
            return Response<UserInfoResponse>.Forbidden("La cuenta está inactiva.");

        var roles = await userManager.GetRolesAsync(user);

        var roleIds = await roleManager.Roles
            .Where(r => roles.Contains(r.Name!))
            .Select(r => r.Id)
            .ToListAsync(cancellationToken);

        var permissions = await unitOfWork.RolePermissions.Query()
            .Where(rp => roleIds.Contains(rp.RoleId))
            .Select(rp => rp.PermissionId)
            .Distinct()
            .ToListAsync(cancellationToken);

        user.LastActivity = DateTime.UtcNow;
        await userManager.UpdateAsync(user);

        return Response<UserInfoResponse>.Success(new UserInfoResponse
        {
            UserId = user.Id,
            UserName = user.UserName!,
            FullName = $"{user.FirstName} {user.LastName}",
            Email = user.Email ?? string.Empty,
            Roles = roles,
            Permissions = permissions.Select(p => p.ToString()).ToList()
        });
    }
}