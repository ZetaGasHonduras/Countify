using System.Security.Claims;
using System.Text.Encodings.Web;
using Countify.Api.ApiKeyAuthentication.Options;
using Countify.Application.Wrappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Countify.Api.ApiKeyAuthentication;

internal sealed class ApiKeyAuthenticationHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    IOptions<ApiKeyAuthenticationOptions> apiKeyOptions)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(apiKeyOptions.Value.HeaderName, out StringValues extractedApiKey))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        if (!string.Equals(apiKeyOptions.Value.ApiKey, extractedApiKey))
        {
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        Claim[] claims = [new Claim(ClaimTypes.NameIdentifier, apiKeyOptions.Value.ClaimName)];
        ClaimsIdentity identity = new(claims, Scheme.Name);
        ClaimsPrincipal principal = new(identity);
        AuthenticationTicket ticket = new(principal, Scheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }

    protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
    {
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        Response.ContentType = "application/json";

        await Response.WriteAsJsonAsync(new Response<string>("Usted no esta autorizado para ejecutar esta acción"));
    }
}