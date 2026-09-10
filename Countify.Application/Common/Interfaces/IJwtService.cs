using Countify.Domain.Entities.Auth;

namespace Countify.Application.Common.Interfaces;

public interface IJwtService
{
    string GenerateAccessToken(ApplicationUser user, IList<string> roles);
    string GenerateRefreshToken();
    string? GetUserIdFromExpiredToken(string accessToken);
}