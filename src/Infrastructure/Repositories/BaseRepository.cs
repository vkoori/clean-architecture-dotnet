namespace Infrastructure.Repositories;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance.EFCore.Extensions;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    #region write
    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedAt = DateTime.Now;
        entity.UpdatedAt = DateTime.Now;
        _dbSet.Add(entity: entity);
        await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return entity;
    }
    public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach(TEntity entity in entities)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            _dbSet.Add(entity: entity);
        }
        await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return entities;
    }
    public virtual async Task<TEntity> UpdateAsync(
        TEntity entity,
        CancellationToken cancellationToken = default
    )
    {
        entity.UpdatedAt = DateTime.Now;
        _dbContext.Entry(entity: entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return entity;
    }
    public virtual async Task<IEnumerable<TEntity>> UpdateRangeAsync(
        IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default
    )
    {
        foreach (TEntity entity in entities)
        {
            entity.UpdatedAt = DateTime.Now;
            _dbContext.Entry(entity: entity).State = EntityState.Modified;
        }
        await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        return entities;
    }
    public virtual async Task<bool> DeleteAsync(
        ulong id,
        CancellationToken cancellationToken = default
    )
    {
        TEntity? entity = await GetByIdAsync(id: id, cancellationToken: cancellationToken);

        if (entity != null)
        {
            if (entity is BaseEntitySoftDelete softDeletableEntity)
            {
                softDeletableEntity.DeletedAt = DateTimeOffset.Now;
                _dbContext.Entry(entity: entity).State = EntityState.Modified;
            }
            else
            {
                _dbSet.Remove(entity: entity);
            }

            entity.UpdatedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        }

        return entity != null;
    }
    #endregion

    #region read
    public async virtual Task<TEntity?> GetByIdAsync(
        ulong id,
        CancellationToken cancellationToken = default
    )
    {
        return await _dbSet.SingleOrDefaultAsync(
            predicate: e => e.Id.Equals(id) && IsEntityNotDeleted(e),
            cancellationToken: cancellationToken
        );
    }
    public async virtual Task<TEntity> GetByIdOrFailAsync(
        ulong id,
        CancellationToken cancellationToken = default
    )
    {
        return await GetByIdAsync(id: id, cancellationToken: cancellationToken) ?? throw new RowNotInTableException();
    }
    public virtual async Task<TEntity?> FirstAsync(
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default
    )
    {
        return await _dbSet.FirstOrDefaultAsync(predicate: filter, cancellationToken: cancellationToken);
    }
    public virtual async Task<TEntity> FirstOrFailAsync(
        Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default
    )
    {
        return await FirstAsync(filter: filter, cancellationToken: cancellationToken) ?? throw new RowNotInTableException();
    }
    public virtual async Task<int> CountAsync(
        Func<TEntity, bool>? filter = null,
        CancellationToken cancellationToken = default
    )
    {
        IQueryable<TEntity> query = _dbSet;

        if (typeof(BaseEntitySoftDelete).IsSubclassOf(typeof(TEntity)))
        {
            query = query.Where(predicate: e => IsEntityNotDeleted(e));
        }

        return await query.Filter(predicate: filter).CountAsync(cancellationToken: cancellationToken);
    }
    public virtual async Task<IEnumerable<TEntity>> ListAsync(
        Func<TEntity, bool>? filter = null,
        bool noTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IQueryable<TEntity> query = _dbSet;

        if (noTracking)
        {
            query.AsNoTracking();
        }
        if (typeof(BaseEntitySoftDelete).IsSubclassOf(typeof(TEntity)))
        {
            query = query.Where(predicate: e => IsEntityNotDeleted(e));
        }

        return await query.Filter(predicate: filter).ToListAsync(cancellationToken: cancellationToken);
    }
    public virtual async Task<IPaginationResult<TEntity>> PaginationAsync(
        int currentPage,
        Func<TEntity, bool>? filter = null,
        bool noTracking = true,
        int perPage = 10,
        CancellationToken cancellationToken = default
    )
    {
        IQueryable<TEntity> query = _dbSet;

        if (noTracking)
        {
            query.AsNoTracking();
        }
        if (typeof(BaseEntitySoftDelete).IsSubclassOf(typeof(TEntity)))
        {
            query = query.Where(predicate: e => IsEntityNotDeleted(e));
        }

        int totalCount = await query.CountAsync(cancellationToken: cancellationToken);

        return new PaginationResult<TEntity>
        {
            CurrentPage = currentPage,
            LastPages = (int)Math.Ceiling((double)totalCount / perPage),
            TotalItems = totalCount,
            Items = await query
                .Skip(count: (currentPage - 1) * perPage)
                .Take(count: perPage)
                .AsQueryable()
                .ToListAsync(cancellationToken: cancellationToken)
        };
    }
    #endregion

    #region ExplicitLoading
    public virtual void Attach(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(paramName: nameof(entity));
        }
        if (_dbContext.Entry(entity: entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity: entity);
        }
    }
    public virtual void Detach(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(paramName: nameof(entity));
        }
        var entry = _dbContext.Entry(entity: entity);
        if (entry != null)
        {
            entry.State = EntityState.Detached;
        }
    }
    public virtual async Task LoadOneAsync<TRelationProperty>(
        TEntity entity,
        Expression<Func<TEntity, TRelationProperty?>> navigationProperty,
        CancellationToken cancellationToken
    ) where TRelationProperty : class
    {
        Attach(entity: entity);
        var reference = _dbContext.Entry(entity: entity).Reference(propertyExpression: navigationProperty);
        if (!reference.IsLoaded)
        {
            await reference.LoadAsync(cancellationToken: cancellationToken);
        }
    }
    public virtual async Task LoadManyAsync<TRelationProperty>(
        TEntity entity,
        Expression<Func<TEntity, IEnumerable<TRelationProperty>>> navigationProperty,
        CancellationToken cancellationToken
    ) where TRelationProperty : class
    {
        Attach(entity: entity);
        var collection = _dbContext.Entry(entity: entity).Collection(propertyExpression: navigationProperty);
        if (!collection.IsLoaded)
        {
            await collection.LoadAsync(cancellationToken: cancellationToken);
        }
    }
    #endregion

    private bool IsEntityNotDeleted(TEntity entity)
    {
        if (entity is BaseEntitySoftDelete softDeletableEntity)
        {
            return softDeletableEntity.DeletedAt == null;
        }

        return true;
    }
}
