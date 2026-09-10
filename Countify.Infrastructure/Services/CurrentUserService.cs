using Countify.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Quick.AutoInject.Services;

namespace Countify.Infrastructure.Services;

[ScopeService]
public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public (Guid UserId, string UserName) GetCurrentUser()
    {
        var user = httpContextAccessor.HttpContext?.User;

        var idClaim = user?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        var nameClaim = user?.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value
                        ?? user?.Identity?.Name
                        ?? "System";

        var userId = Guid.TryParse(idClaim, out var parsed) ? parsed : Guid.Empty;

        return (userId, nameClaim);
    }
}