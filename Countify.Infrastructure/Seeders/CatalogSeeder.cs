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

        await SeedDepartmentsAsync(cancellationToken);
        await SeedProjectCatalogAsync(cancellationToken);
        await SeedAccountsAsync(cancellationToken);
        await SeedDocumentTypeAsync(cancellationToken);
        await SeedAccountingPeriodsAsync(cancellationToken);
        await SeedJournalEntriesAsync(cancellationToken);
        await SeedYearEndClosingEntriesAsync(cancellationToken);
        await SeedHistoriesAsync(cancellationToken);
        await SeedCompanySettingsAsync(cancellationToken);

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

    private async Task SeedJournalEntriesAsync(CancellationToken cancellationToken)
    {
        if (await context.JournalEntries.AnyAsync(cancellationToken))
            return;

        context.JournalEntries.AddRange(BasicJournalEntries.Items);
    }

    private async Task SeedHistoriesAsync(CancellationToken cancellationToken)
    {
        if (await context.Histories.AnyAsync(cancellationToken))
            return;

        context.Histories.AddRange(BasicHistories.Items);
    }

    private async Task SeedYearEndClosingEntriesAsync(CancellationToken cancellationToken)
    {
        if (await context.YearEndClosingEntries.AnyAsync(cancellationToken))
            return;

        context.YearEndClosingEntries.AddRange(BasicYearEndClosingEntries.Items);
    }

    private async Task SeedCompanySettingsAsync(CancellationToken cancellationToken)
    {
        if (await context.CompanySettings.AnyAsync(cancellationToken))
            return;

        context.CompanySettings.AddRange(BasicCompanySettings.Items);
    }
}