using Countify.Domain.Interfaces;
using Countify.Domain.Seeders;
using Countify.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Countify.Infrastructure.Seeders;

public class TransactionSeeder(
    CountifyDbContext context,
    IOptions<SeederOptions> options,
    ILogger<TransactionSeeder> logger) : ISeeder
{
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (!options.Value.Enabled)
        {
            logger.LogInformation("Transaction seeding skipped: Seeder:Enabled=false.");
            return;
        }

        if (!options.Value.SeedTransactions)
        {
            logger.LogInformation("Transaction seeding skipped: Seeder:SeedTransactions=false.");
            return;
        }

        await SeedJournalEntriesAsync(cancellationToken);
        await SeedYearEndClosingEntriesAsync(cancellationToken);
        await SeedHistoriesAsync(cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        logger.LogInformation("Transaction seed completed.");
    }

    private async Task SeedJournalEntriesAsync(CancellationToken cancellationToken)
    {
        if (await context.JournalEntries.AnyAsync(cancellationToken))
            return;

        context.JournalEntries.AddRange(BasicJournalEntries.Items);
    }

    private async Task SeedYearEndClosingEntriesAsync(CancellationToken cancellationToken)
    {
        if (await context.YearEndClosingEntries.AnyAsync(cancellationToken))
            return;

        context.YearEndClosingEntries.AddRange(BasicYearEndClosingEntries.Items);
    }

    private async Task SeedHistoriesAsync(CancellationToken cancellationToken)
    {
        if (await context.Histories.AnyAsync(cancellationToken))
            return;

        context.Histories.AddRange(BasicHistories.Items);
    }
}
