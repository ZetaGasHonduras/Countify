using Countify.Application.Common.Interfaces;
using Countify.Application.Features.Auth.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using Countify.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Countify.Application.Features.Auth.Commands.Login;

public record LoginCommand(string UserName, string Password) : IRequest<Response<AuthResponse>>;

public class LoginCommandHandler(
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IJwtService jwtService,
    IUnitOfWork unitOfWork)
    : IRequestHandler<LoginCommand, Response<AuthResponse>>
{
    public async Task<Response<AuthResponse>> Handle(
        LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.UserName);
        if (user is null)
            return Response<AuthResponse>.Failure("Credenciales inválidas.", 401);

        if (!user.IsActive)
            return Response<AuthResponse>.Failure("La cuenta está inactiva. Contacte al administrador.", 403);

        if (await userManager.IsLockedOutAsync(user))
            return Response<AuthResponse>.Failure(
                $"Cuenta bloqueada. Intente nuevamente después de {user.LockoutEnd?.ToLocalTime():HH:mm}.", 403);

        var passwordValid = await userManager.CheckPasswordAsync(user, request.Password);

        if (!passwordValid)
        {
            await userManager.AccessFailedAsync(user);

            if (await userManager.IsLockedOutAsync(user))
                return Response<AuthResponse>.Failure("Cuenta bloqueada por múltiples intentos fallidos.", 403);

            return Response<AuthResponse>.Failure("Credenciales inválidas.", 401);
        }

        await userManager.ResetAccessFailedCountAsync(user);

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

        var accessToken = jwtService.GenerateAccessToken(user, roles);
        var refreshToken = jwtService.GenerateRefreshToken();
        var expires = DateTime.UtcNow.AddMinutes(60);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        user.LastActivity = DateTime.UtcNow;
        await userManager.UpdateAsync(user);

        return Response<AuthResponse>.Success(new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = expires,
            UserId = user.Id,
            UserName = user.UserName!,
            FullName = $"{user.FirstName} {user.LastName}",
            Roles = roles,
            Permissions = permissions.Select(p => p.ToString()).ToList()
        });
    }
}