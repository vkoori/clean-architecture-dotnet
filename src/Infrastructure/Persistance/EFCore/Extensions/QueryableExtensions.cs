namespace Infrastructure.Persistance.EFCore.Extensions;

using System;
using System.Linq;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> Filter<TEntity>(
        this IQueryable<TEntity> query,
        Func<TEntity, bool>? predicate = null)
    {
        if (predicate != null)
        {
            query = query.Where(predicate).AsQueryable();
        }

        return query;
    }
}
