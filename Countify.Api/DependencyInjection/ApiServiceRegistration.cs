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
        services.ConfigureOptions<ProductAccountPolicies>();
        services.ConfigureOptions<RolePolicies>();
        services.ConfigureOptions<UserPolicies>();
        services.ConfigureOptions<HistoryPolicies>();
        services.ConfigureOptions<ReportsPolicies>();
        services.ConfigureOptions<BudgetPolicies>();
        services.ConfigureOptions<BankPolicies>();
        services.ConfigureOptions<CurrencyPolicies>();

        services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        return services;
    }
}
