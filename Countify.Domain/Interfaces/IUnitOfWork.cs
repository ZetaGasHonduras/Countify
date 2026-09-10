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

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}