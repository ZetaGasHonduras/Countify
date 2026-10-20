using Countify.Domain.Interfaces;
using Countify.Domain.Seeders;
using Countify.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Countify.Infrastructure.Seeders;

public class CatalogSeeder(
    CountifyDbContext context,
    IOptions<SeederOptions> options,
    ILogger<CatalogSeeder> logger) : ISeeder
{
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (!options.Value.Enabled)
        {
            logger.LogInformation("Seeding skipped: Seeder:Enabled=false.");
            return;
        }

        if (!options.Value.SeedConfiguration && !options.Value.SeedTransactions)
        {
            logger.LogInformation("Catalog seeding skipped: SeedConfiguration=false and SeedTransactions=false.");
            return;
        }

        if (options.Value.SeedConfiguration)
        {
            await SeedAccountsAsync(cancellationToken);
            await SeedCurrenciesAsync(cancellationToken);
            await SeedDocumentTypeAsync(cancellationToken);
            await SeedPaymentMethodsAsync(cancellationToken);
        }

        if (options.Value.SeedTransactions)
        {
            await SeedDepartmentsAsync(cancellationToken);
            await SeedProjectCatalogAsync(cancellationToken);
            await SeedBanksAsync(cancellationToken);
            await SeedBudgetsAsync(cancellationToken);
            await SeedProductCatalogAsync(cancellationToken);
            await SeedProductAccountsAsync(cancellationToken);
            await SeedAccountingPeriodsAsync(cancellationToken);
            await SeedCustomerCatalogAsync(cancellationToken);
            await SeedSupplierCatalogAsync(cancellationToken);
            await SeedAccountsReceivableConceptsAsync(cancellationToken);
            await SeedPayableConceptsAsync(cancellationToken);
        }
        await context.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Catalog seed completed.");
    }

    private async Task SeedPaymentMethodsAsync(CancellationToken cancellationToken)
    {
        if (await context.PaymentMethods.AnyAsync(cancellationToken))
            return;

        context.PaymentMethods.AddRange(BasicPaymentMethods.Items);
    }

    private async Task SeedDepartmentsAsync(CancellationToken cancellationToken)
    {
        if (await context.Departments.AnyAsync(cancellationToken))
            return;

        context.Departments.AddRange(BasicDepartments.Items);
    }

    private async Task SeedProjectCatalogAsync(CancellationToken cancellationToken)
    {
        if (!await context.ProjectGroups.AnyAsync(cancellationToken))
            context.ProjectGroups.AddRange(BasicProjectGroups.Items);

        if (!await context.Projects.AnyAsync(cancellationToken))
            context.Projects.AddRange(BasicProjects.Items);
    }

    private async Task SeedAccountsAsync(CancellationToken cancellationToken)
    {
        if (await context.Accounts.AnyAsync(cancellationToken))
            return;

        context.Accounts.AddRange(BasicAccounts.Items);
    }

    private async Task SeedBanksAsync(CancellationToken cancellationToken)
    {
        if (!await context.BankAccounts.AnyAsync(cancellationToken))
            context.BankAccounts.AddRange(BasicBanks.Accounts);
        else
        {
            var seededBank = await context.BankAccounts
                .FirstOrDefaultAsync(bank => bank.Code == BasicBanks.MainBank.Code, cancellationToken);
            if (seededBank is not null)
                seededBank.AccountingAccountId = BasicAccounts.Banks.Id;
        }
        if (!await context.BankTransactionTypes.AnyAsync(cancellationToken))
            context.BankTransactionTypes.AddRange(BasicBanks.TransactionTypes);
    }

    private async Task SeedCurrenciesAsync(CancellationToken cancellationToken)
    {
        if (!await context.Currencies.AnyAsync(cancellationToken))
            context.Currencies.AddRange(BasicCurrencies.Items);
    }

    private async Task SeedProductCatalogAsync(CancellationToken cancellationToken)
    {
        if (!await context.Products.AnyAsync(cancellationToken))
            context.Products.AddRange(BasicProducts.Items);

        if (!await context.Qualities.AnyAsync(cancellationToken))
            context.Qualities.AddRange(BasicQualities.Items);
    }

    private async Task SeedBudgetsAsync(CancellationToken cancellationToken)
    {
        if (await context.Budgets.AnyAsync(cancellationToken)) return;
        context.Budgets.AddRange(BasicBudgets.Items);
    }

    private async Task SeedProductAccountsAsync(CancellationToken cancellationToken)
    {
        if (await context.ProductAccounts.AnyAsync(cancellationToken))
            return;

        context.ProductAccounts.AddRange(BasicProductAccounts.Items);
    }

    private async Task SeedDocumentTypeAsync(CancellationToken cancellationToken)
    {
        if (await context.DocumentTypes.AnyAsync(d => d.IsDefault, cancellationToken))
            return;

        context.DocumentTypes.AddRange(BasicDocumentTypes.Items);
    }

    private async Task SeedAccountingPeriodsAsync(CancellationToken cancellationToken)
    {
        if (await context.AccountingPeriods.AnyAsync(cancellationToken))
            return;

        context.AccountingPeriods.AddRange(BasicAccountingPeriods.Items);
    }

    private async Task SeedCustomerCatalogAsync(CancellationToken cancellationToken)
    {
        if (!await context.CustomerTypes.AnyAsync(cancellationToken))
        {
            var arAccount = await context.Accounts
                .FirstOrDefaultAsync(account => account.Code == BasicAccounts.AccountsReceivable.Code, cancellationToken);

            foreach (var item in BasicCustomerTypes.Items)
                item.AccountingAccountId = arAccount?.Id;

            context.CustomerTypes.AddRange(BasicCustomerTypes.Items);
        }

        if (!await context.Customers.AnyAsync(cancellationToken))
        {
            var creditType = await context.CustomerTypes
                .FirstOrDefaultAsync(type => type.Code == BasicCustomerTypes.Credit.Code, cancellationToken);
            var arAccount = await context.Accounts
                .FirstOrDefaultAsync(account => account.Code == BasicAccounts.AccountsReceivable.Code, cancellationToken);

            foreach (var item in BasicCustomers.Items)
            {
                item.CustomerTypeId = ReferenceEquals(item, BasicCustomers.CashCustomer) ? null : creditType?.Id;
                item.AccountingAccountId = ReferenceEquals(item, BasicCustomers.CashCustomer) ? null : arAccount?.Id;
            }

            context.Customers.AddRange(BasicCustomers.Items);
        }
    }

    private async Task SeedAccountsReceivableConceptsAsync(CancellationToken cancellationToken)
    {
        if (await context.AccountsReceivableConcepts.AnyAsync(cancellationToken))
            return;

        var arAccount = await context.Accounts
            .FirstOrDefaultAsync(account => account.Code == BasicAccounts.AccountsReceivable.Code, cancellationToken);

        foreach (var item in BasicAccountsReceivableConcepts.Items)
        {
            if (ReferenceEquals(item, BasicAccountsReceivableConcepts.Receipt) ||
                ReferenceEquals(item, BasicAccountsReceivableConcepts.DownPayment))
                continue;

            item.AccountId = arAccount?.Id;
        }

        context.AccountsReceivableConcepts.AddRange(BasicAccountsReceivableConcepts.Items);
    }

    private async Task SeedPayableConceptsAsync(CancellationToken cancellationToken)
    {
        if (await context.PayableConcepts.AnyAsync(cancellationToken))
            return;

        var apAccount = await context.Accounts
            .FirstOrDefaultAsync(account => account.Code == BasicAccounts.SuppliersPayableLocal.Code, cancellationToken);

        foreach (var item in BasicPayableConcepts.Items)
        {
            // Solo la compra lleva cuenta por defecto; el pago usa la cuenta del proveedor (FASE 4.4).
            if (ReferenceEquals(item, BasicPayableConcepts.Payment))
                continue;

            item.AccountId = apAccount?.Id;
        }

        context.PayableConcepts.AddRange(BasicPayableConcepts.Items);
    }

    private async Task SeedSupplierCatalogAsync(CancellationToken cancellationToken)
    {
        if (!await context.SupplierTypes.AnyAsync(cancellationToken))
        {
            var accountIds = await GetSupplierAccountIdsAsync(cancellationToken);

            foreach (var item in BasicSupplierTypes.Items)
            {
                if (BasicSupplierTypes.AccountCodesByTypeCode.TryGetValue(item.Code, out var accountCode))
                    item.AccountingAccountId = accountIds.GetValueOrDefault(accountCode);
            }

            context.SupplierTypes.AddRange(BasicSupplierTypes.Items);
        }

        if (!await context.Suppliers.AnyAsync(cancellationToken))
        {
            var creditType = await context.SupplierTypes
                .FirstOrDefaultAsync(type => type.Code == BasicSupplierTypes.Default.Code, cancellationToken);
            var foreignType = await context.SupplierTypes
                .FirstOrDefaultAsync(type => type.Code == BasicSupplierTypes.Foreign.Code, cancellationToken);
            var accountIds = await GetSupplierAccountIdsAsync(cancellationToken);

            foreach (var item in BasicSuppliers.Items)
            {
                var typeCode = BasicSuppliers.TypeCodes.GetValueOrDefault(item);
                item.SupplierTypeId = typeCode == BasicSupplierTypes.Foreign.Code ? foreignType?.Id : creditType?.Id;

                if (BasicSuppliers.AccountCodes.TryGetValue(item, out var accountCode))
                    item.AccountingAccountId = accountIds.GetValueOrDefault(accountCode);
            }

            context.Suppliers.AddRange(BasicSuppliers.Items);
            context.SupplierFiscalData.Add(BasicSuppliers.ProviderGeneralFiscal);
        }
    }

    private async Task<Dictionary<string, Guid?>> GetSupplierAccountIdsAsync(CancellationToken cancellationToken)
        => await context.Accounts
            .Where(account => account.Code == BasicAccounts.SuppliersPayableLocal.Code
                           || account.Code == BasicAccounts.SuppliersPayableForeign.Code)
            .ToDictionaryAsync(account => account.Code, account => (Guid?)account.Id, cancellationToken);

}
