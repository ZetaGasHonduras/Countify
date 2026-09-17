using Countify.Api.Authorization.Handlers;
using Countify.Api.Authorization.Policies;
using Microsoft.AspNetCore.Authorization;

namespace Countify.Api.DependencyInjection;

public static class ApiServiceRegistration
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.ConfigureOptions<DepartmentPolicies>();
        services.ConfigureOptions<ProjectGroupPolicies>();
        services.ConfigureOptions<ProjectPolicies>();
        services.ConfigureOptions<DocumentTypePolicies>();
        services.ConfigureOptions<AccountPolicies>();
        services.ConfigureOptions<AccountingPeriodPolicies>();
        services.ConfigureOptions<JournalEntryPolicies>();
        services.ConfigureOptions<CompanySettingsPolicies>();
        services.ConfigureOptions<RolePolicies>();
        services.ConfigureOptions<UserPolicies>();
        services.ConfigureOptions<HistoryPolicies>();

        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        return services;
    }
}