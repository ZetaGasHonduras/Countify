using Microsoft.Extensions.Options;

namespace Countify.Api.ApiKeyAuthentication.Options;

internal sealed class ApiKeyAuthenticationOptionsSetup(
    IConfiguration configuration) : IConfigureOptions<ApiKeyAuthenticationOptions>
{
    public void Configure(ApiKeyAuthenticationOptions options) =>
        configuration.GetSection(ApiKeyAuthenticationDefaults.ConfigurationSectionName).Bind(options);
}