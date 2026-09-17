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
    public DbSet<ProductAccount> ProductAccounts { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<CompanySettings> CompanySettings { get; set; }
    public DbSet<JournalEntry> JournalEntries { get; set; }
    public DbSet<JournalEntryLine> JournalEntryLines { get; set; }
    public DbSet<YearEndClosingEntry> YearEndClosingEntries { get; set; }

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

            switch (entry.State)
            {
                case EntityState.Added:
                {
                    histories.AddRange(entry.Properties.Select(prop => new History
                    {
                        Id = Guid.NewGuid(),
                        Entity = entityName,
                        Property = prop.Metadata.Name,
                        EntityId = entityId,
                        Date = now,
                        UserId = userId,
                        UserName = userName,
                        OldValue = string.Empty,
                        NewValue = prop.CurrentValue?.ToString() ?? string.Empty
                    }));

                    break;
                }
                case EntityState.Modified:
                {
                    histories.AddRange(entry.Properties.Where(p => p.IsModified)
                        .Select(prop => new History
                        {
                            Id = Guid.NewGuid(),
                            Entity = entityName,
                            Property = prop.Metadata.Name,
                            EntityId = entityId,
                            Date = now,
                            UserId = userId,
                            UserName = userName,
                            OldValue = prop.OriginalValue?.ToString() ?? string.Empty,
                            NewValue = prop.CurrentValue?.ToString() ?? string.Empty
                        }));

                    break;
                }
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
}