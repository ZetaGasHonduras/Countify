using Countify.Domain.Entities.Accounting;
using Countify.Domain.Entities.Audit;
using Countify.Domain.Entities.Auth;
using Countify.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Quick.AutoInject.Services;

namespace Countify.Infrastructure.Persistence.Services;

[ScopeService]
public class UnitOfWork(CountifyDbContext context) : IUnitOfWork
{
    private IRepository<ApplicationUser>? _users;
    private IRepository<IdentityRole>? _roles;
    private IRepository<RolePermission>? _rolePermissions;
    private IRepository<Permission>? _permissions;
    private IRepository<History>? _histories;

    private IRepository<Account>? _accounts;
    private IRepository<DocumentType>? _documentTypes;
    private IRepository<AccountingPeriod>? _accountingPeriods;
    private IRepository<ProjectGroup>? _projectGroups;
    private IRepository<Project>? _projects;
    private IRepository<ProductAccount>? _productAccounts;
    private IRepository<Department>? _departments;
    private IRepository<CompanySettings>? _companySettings;
    private IRepository<JournalEntry>? _journalEntries;
    private IRepository<JournalEntryLine>? _journalEntryLines;
    private IRepository<YearEndClosingEntry>? _yearEndClosingEntries;

    public IRepository<ApplicationUser> Users =>
        _users ??= new Repository<ApplicationUser>(context);

    public IRepository<IdentityRole> Roles =>
        _roles ??= new Repository<IdentityRole>(context);

    public IRepository<RolePermission> RolePermissions =>
        _rolePermissions ??= new Repository<RolePermission>(context);

    public IRepository<Permission> Permissions =>
        _permissions ??= new Repository<Permission>(context);

    public IRepository<History> Histories =>
        _histories ??= new Repository<History>(context);

    public IRepository<Account> Accounts =>
        _accounts ??= new Repository<Account>(context);

    public IRepository<DocumentType> DocumentTypes =>
        _documentTypes ??= new Repository<DocumentType>(context);

    public IRepository<AccountingPeriod> AccountingPeriods =>
        _accountingPeriods ??= new Repository<AccountingPeriod>(context);

    public IRepository<ProjectGroup> ProjectGroups =>
        _projectGroups ??= new Repository<ProjectGroup>(context);

    public IRepository<Project> Projects =>
        _projects ??= new Repository<Project>(context);

    public IRepository<ProductAccount> ProductAccounts =>
        _productAccounts ??= new Repository<ProductAccount>(context);

    public IRepository<Department> Departments =>
        _departments ??= new Repository<Department>(context);

    public IRepository<CompanySettings> CompanySettings =>
        _companySettings ??= new Repository<CompanySettings>(context);

    public IRepository<JournalEntry> JournalEntries =>
        _journalEntries ??= new Repository<JournalEntry>(context);

    public IRepository<JournalEntryLine> JournalEntryLines =>
        _journalEntryLines ??= new Repository<JournalEntryLine>(context);

    public IRepository<YearEndClosingEntry> YearEndClosingEntries =>
        _yearEndClosingEntries ??= new Repository<YearEndClosingEntry>(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);
    
    public void Dispose() => context.Dispose();
}