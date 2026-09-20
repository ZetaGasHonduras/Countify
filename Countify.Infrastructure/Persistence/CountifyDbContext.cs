using System.Globalization;
using Countify.Application.Common.Interfaces;
using Countify.Domain.Common;
using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.Audit;
using Countify.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Countify.Infrastructure.Persistence;

public class CountifyDbContext(DbContextOptions<CountifyDbContext> options, ICurrentUserService currentUserService)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<History> Histories { get; set; }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<AccountingPeriod> AccountingPeriods { get; set; }
    public DbSet<ProjectGroup> ProjectGroups { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Quality> Qualities { get; set; }
    public DbSet<ProductAccount> ProductAccounts { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<CompanySettings> CompanySettings { get; set; }
    public DbSet<JournalEntry> JournalEntries { get; set; }
    public DbSet<JournalEntryLine> JournalEntryLines { get; set; }
    public DbSet<YearEndClosingEntry> YearEndClosingEntries { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<BudgetLine> BudgetLines { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<BankTransactionType> BankTransactionTypes { get; set; }
    public DbSet<BankTransaction> BankTransactions { get; set; }
    public DbSet<BankReconciliation> BankReconciliations { get; set; }
    public DbSet<Currency> Currencies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CountifyDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added && entry.Entity.Id == Guid.Empty)
                entry.Entity.Id = Guid.NewGuid();
        }

        var historyEntries = BuildHistoryEntries();
        if (historyEntries.Count > 0)
            Histories.AddRange(historyEntries);

        return await base.SaveChangesAsync(cancellationToken);
    }

    private static readonly HashSet<string> IgnoredProperties = new(StringComparer.Ordinal)
    {
        nameof(BaseEntity.Id),
        nameof(JournalEntry.EntryGid),
        nameof(JournalEntryLine.LineGid)
    };

    private List<History> BuildHistoryEntries()
    {
        var (userId, userName) = currentUserService.GetCurrentUser();
        var histories = new List<History>();
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.Entity is History) continue;

            if (entry.State is not (EntityState.Added or EntityState.Modified or EntityState.Deleted))
                continue;

            var entityName = entry.Entity.GetType().Name;
            var entityId = entry.Entity.Id;

            var properties = entry.Properties
                .Where(p => !IgnoredProperties.Contains(p.Metadata.Name))
                .ToList();

            switch (entry.State)
            {
                case EntityState.Added:
                    histories.AddRange(properties
                        .Where(prop => !IsNoise(FormatValue(prop.CurrentValue)))
                        .Select(prop => new History
                        {
                            Id = Guid.NewGuid(),
                            Entity = entityName,
                            Property = prop.Metadata.Name,
                            EntityId = entityId,
                            Date = now,
                            UserId = userId,
                            UserName = userName,
                            OldValue = string.Empty,
                            NewValue = FormatValue(prop.CurrentValue)
                        }));

                    break;
                case EntityState.Modified:
                    histories.AddRange(properties
                        .Where(p => p.IsModified &&
                                    FormatValue(p.OriginalValue) != FormatValue(p.CurrentValue))
                        .Select(prop => new History
                        {
                            Id = Guid.NewGuid(),
                            Entity = entityName,
                            Property = prop.Metadata.Name,
                            EntityId = entityId,
                            Date = now,
                            UserId = userId,
                            UserName = userName,
                            OldValue = FormatValue(prop.OriginalValue),
                            NewValue = FormatValue(prop.CurrentValue)
                        }));

                    break;
                case EntityState.Deleted:
                    histories.Add(new History
                    {
                        Id = Guid.NewGuid(),
                        Entity = entityName,
                        Property = "—",
                        EntityId = entityId,
                        Date = now,
                        UserId = userId,
                        UserName = userName,
                        OldValue = "Active",
                        NewValue = "Deleted"
                    });
                    break;
            }
        }

        return histories;
    }

    private static string FormatValue(object? value)
    {
        if (value is null) return string.Empty;
        if (value is DateTime dateTime) return dateTime.ToString("O");
        if (value is DateTimeOffset dateTimeOffset) return dateTimeOffset.ToString("O");
        if (value.GetType().IsEnum) return Enum.GetName(value.GetType(), value) ?? string.Empty;
        return Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty;
    }

    private static bool IsNoise(string formatted)
    {
        if (string.IsNullOrWhiteSpace(formatted)) return true;
        if (formatted == "0" || formatted == "False") return true;
        return Guid.TryParse(formatted, out var guid) && guid == Guid.Empty;
    }
}
