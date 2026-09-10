using Countify.Api.Authorization.Handlers;
using Countify.Api.Authorization.Policies;
using Microsoft.AspNetCore.Authorization;

namespace Countify.Api.DependencyInjection;

public static class ApiServiceRegistration
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.ConfigureOptions<RolePolicies>();
        services.ConfigureOptions<UserPolicies>();

        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        return services;
    }
}