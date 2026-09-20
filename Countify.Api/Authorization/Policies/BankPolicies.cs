using Countify.Api.Authorization.Requirements;
using Countify.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Countify.Api.Authorization.Policies;
internal sealed class BankPolicies : IConfigureOptions<AuthorizationOptions>
{
    internal const string ViewAccounts=nameof(ViewAccounts); internal const string CreateAccounts=nameof(CreateAccounts); internal const string EditAccounts=nameof(EditAccounts); internal const string DeleteAccounts=nameof(DeleteAccounts);
    internal const string ViewTypes=nameof(ViewTypes); internal const string CreateTypes=nameof(CreateTypes); internal const string EditTypes=nameof(EditTypes); internal const string DeleteTypes=nameof(DeleteTypes);
    internal const string ViewTransactions=nameof(ViewTransactions); internal const string CreateTransactions=nameof(CreateTransactions); internal const string EditTransactions=nameof(EditTransactions); internal const string DeleteTransactions=nameof(DeleteTransactions); internal const string ViewReconciliations=nameof(ViewReconciliations); internal const string CreateReconciliations=nameof(CreateReconciliations); internal const string EditReconciliations=nameof(EditReconciliations); internal const string Unreconcile=nameof(Unreconcile);
    public void Configure(AuthorizationOptions o){Add(o,ViewAccounts,Permissions.CanViewBankAccounts);Add(o,CreateAccounts,Permissions.CanCreateBankAccounts);Add(o,EditAccounts,Permissions.CanEditBankAccounts);Add(o,DeleteAccounts,Permissions.CanDeleteBankAccounts);Add(o,ViewTypes,Permissions.CanViewBankTransactionTypes);Add(o,CreateTypes,Permissions.CanCreateBankTransactionTypes);Add(o,EditTypes,Permissions.CanEditBankTransactionTypes);Add(o,DeleteTypes,Permissions.CanDeleteBankTransactionTypes);Add(o,ViewTransactions,Permissions.CanViewBankTransactions);Add(o,CreateTransactions,Permissions.CanCreateBankTransactions);Add(o,EditTransactions,Permissions.CanEditBankTransactions);Add(o,DeleteTransactions,Permissions.CanDeleteBankTransactions);Add(o,ViewReconciliations,Permissions.CanViewBankReconciliations);Add(o,CreateReconciliations,Permissions.CanCreateBankReconciliations);Add(o,EditReconciliations,Permissions.CanEditBankReconciliations);Add(o,Unreconcile,Permissions.CanUnreconcileBankTransactions);}
    private static void Add(AuthorizationOptions o,string name,Countify.Domain.Entities.Auth.Permission p)=>o.AddPolicy(name,x=>x.AddRequirements(new UserRoleHasPermissionRequirement(p)));
}
