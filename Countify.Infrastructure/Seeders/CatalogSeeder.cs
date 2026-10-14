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
            await SeedAccountsReceivableConceptsAsync(cancellationToken);
        }
        await context.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Catalog seed completed.");
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

}
