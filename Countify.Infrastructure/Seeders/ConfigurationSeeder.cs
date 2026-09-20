using Countify.Domain.Interfaces;
using Countify.Domain.Seeders;
using Countify.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Countify.Infrastructure.Seeders;

/// <summary>
/// Seeds singleton configuration records migrated from the legacy Controles object.
/// </summary>
public class ConfigurationSeeder(
    CountifyDbContext context,
    IOptions<SeederOptions> options,
    ILogger<ConfigurationSeeder> logger) : ISeeder
{
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (!options.Value.Enabled)
        {
            logger.LogInformation("Configuration seeding skipped: Seeder:Enabled=false.");
            return;
        }

        if (!options.Value.SeedConfiguration)
        {
            logger.LogInformation("Configuration seeding skipped: Seeder:SeedConfiguration=false.");
            return;
        }

        if (await context.CompanySettings.AnyAsync(cancellationToken))
        {
            logger.LogInformation("CompanySettings already contains configuration; seeding skipped.");
            return;
        }

        context.CompanySettings.AddRange(BasicCompanySettings.Items);
        await context.SaveChangesAsync(cancellationToken);
        logger.LogInformation("CompanySettings seed completed.");
    }
}
