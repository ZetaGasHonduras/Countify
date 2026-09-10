using Countify.Application.Common.Interfaces;
using Countify.Application.Features.Auth.DTOs;
using Countify.Application.Wrappers;
using Countify.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Countify.Application.Features.Auth.Commands.RefreshToken;

public record RefreshTokenCommand(string AccessToken, string RefreshToken) : IRequest<Response<AuthResponse>>;

public class RefreshTokenCommandHandler(
    UserManager<ApplicationUser> userManager,
    IJwtService jwtService)
    : IRequestHandler<RefreshTokenCommand, Response<AuthResponse>>
{
    public async Task<Response<AuthResponse>> Handle(
        RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var userId = jwtService.GetUserIdFromExpiredToken(request.AccessToken);
        if (userId is null)
            return Response<AuthResponse>.Failure("Token inválido.", 401);

        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
            return Response<AuthResponse>.NotFound("Usuario no encontrado.");

        if (!user.IsActive)
            return Response<AuthResponse>.Failure("La cuenta está inactiva.", 403);

        if (user.RefreshToken != request.RefreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            return Response<AuthResponse>.Failure("Refresh token inválido o expirado.", 401);

        var roles = await userManager.GetRolesAsync(user);
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
            Roles = roles
        });
    }
}