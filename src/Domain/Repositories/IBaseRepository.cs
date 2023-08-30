namespace Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    #region write
    Task<TEntity> AddAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    );
    Task<IEnumerable<TEntity>> AddRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default
    );
    Task<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    );
    Task<IEnumerable<TEntity>> UpdateRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default
    );
    Task<bool> DeleteAsync(
        ulong id,
        CancellationToken cancellationToken = default
    );
    /* Task<bool> DeleteRangeAsync(
        IEnumerable<int> id,
        CancellationToken cancellationToken = default
    ); */
    #endregion

    #region read
    Task<TEntity?> GetByIdAsync(
        ulong id,
        CancellationToken cancellationToken = default
    );
    Task<TEntity> GetByIdOrFailAsync(
        ulong id,
        CancellationToken cancellationToken = default
    );
    Task<TEntity?> FirstAsync(
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default
    );
    Task<TEntity> FirstOrFailAsync(
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default
    );
    Task<int> CountAsync(
        Func<TEntity, bool>? filter = null,
        CancellationToken cancellationToken = default
    );
    Task<IEnumerable<TEntity>> ListAsync(
        Func<TEntity, bool>? filter = null,
        bool noTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginationResult<TEntity>> PaginationAsync(
        int currentPage,
        Func<TEntity, bool>? filter = null,
        bool noTracking = true,
        int perPage = 10,
        CancellationToken cancellationToken = default
    );
    #endregion

    #region ExplicitLoading
    void Attach(TEntity entity);
    void Detach(TEntity entity);
    Task LoadOneAsync<TRelationProperty>(
        TEntity entity,
        Expression<Func<TEntity, TRelationProperty?>> navigationProperty,
        CancellationToken cancellationToken
    ) where TRelationProperty : class;
    Task LoadManyAsync<TRelationProperty>(
        TEntity entity,
        Expression<Func<TEntity, IEnumerable<TRelationProperty>>> navigationProperty,
        CancellationToken cancellationToken
    ) where TRelationProperty : class;
    #endregion
}
