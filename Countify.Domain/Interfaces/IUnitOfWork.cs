using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.Audit;
using Countify.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace Countify.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<ApplicationUser> Users { get; }
    IRepository<IdentityRole> Roles { get; }
    IRepository<RolePermission> RolePermissions { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<History> Histories { get; }

    IRepository<Account> Accounts { get; }
    IRepository<DocumentType> DocumentTypes { get; }
    IRepository<AccountingPeriod> AccountingPeriods { get; }
    IRepository<ProjectGroup> ProjectGroups { get; }
    IRepository<Project> Projects { get; }
    IRepository<Product> Products { get; }
    IRepository<Quality> Qualities { get; }
    IRepository<ProductAccount> ProductAccounts { get; }
    IRepository<Department> Departments { get; }
    IRepository<CompanySettings> CompanySettings { get; }
    IRepository<JournalEntry> JournalEntries { get; }
    IRepository<JournalEntryLine> JournalEntryLines { get; }
    IRepository<YearEndClosingEntry> YearEndClosingEntries { get; }
    IRepository<Budget> Budgets { get; }
    IRepository<BudgetLine> BudgetLines { get; }
    IRepository<BankAccount> BankAccounts { get; }
    IRepository<BankTransactionType> BankTransactionTypes { get; }
    IRepository<BankTransaction> BankTransactions { get; }
    IRepository<BankReconciliation> BankReconciliations { get; }
    IRepository<Currency> Currencies { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
