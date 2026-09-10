using System.Linq.Expressions;

namespace Countify.Application.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> query,
        bool condition,
        Expression<Func<T, bool>> predicate)
        => condition ? query.Where(predicate) : query;

    public static IQueryable<T> ApplySearch<T>(
        this IQueryable<T> query,
        string? search,
        Expression<Func<T, bool>> predicate)
        => !string.IsNullOrWhiteSpace(search) ? query.Where(predicate) : query;

    public static IQueryable<T> ApplyOrder<T>(
        this IQueryable<T> query,
        string? column,
        bool descending,
        Expression<Func<T, object>> defaultOrder,
        Dictionary<string, Expression<Func<T, object>>>? columnMap = null)
    {
        Expression<Func<T, object>> orderExpr = defaultOrder;

        if (!string.IsNullOrWhiteSpace(column) && columnMap is not null &&
            columnMap.TryGetValue(column, out var mapped))
            orderExpr = mapped;

        return descending
            ? query.OrderByDescending(orderExpr)
            : query.OrderBy(orderExpr);
    }
}