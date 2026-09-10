using Microsoft.AspNetCore.Authorization;

namespace Countify.Api.ApiKeyAuthentication;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute  : AuthorizeAttribute
{
    public ApiKeyAttribute()
    {
        AuthenticationSchemes = ApiKeyAuthenticationDefaults.AuthenticationScheme;
    }
}