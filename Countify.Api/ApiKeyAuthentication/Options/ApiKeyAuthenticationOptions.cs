namespace Countify.Api.ApiKeyAuthentication.Options;

public sealed class ApiKeyAuthenticationOptions
{
    public string HeaderName { get; init; } = "x-api-pt";

    public string ClaimName { get; init; } = "Anónimo";

    public string ApiKey { get; init; } = "eee2ca3780b2e48a3968c1d428c3c7e34f5cbf30dbdc94fa27764428b1ef1a37";
}