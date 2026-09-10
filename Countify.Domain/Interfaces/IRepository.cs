using System.Linq.Expressions;

namespace Countify.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    // Lectura puntual
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    // Composición libre
    IQueryable<T> Query();

    // Materialización
    Task<int> CountAsync(IQueryable<T> query, CancellationToken cancellationToken = default);
    Task<List<T>> ToListAsync(IQueryable<T> query, CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefaultAsync(IQueryable<T> query, CancellationToken cancellationToken = default);

    // Escritura
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}