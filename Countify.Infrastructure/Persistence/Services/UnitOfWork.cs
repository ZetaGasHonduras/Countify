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

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);
    
    public void Dispose() => context.Dispose();
}