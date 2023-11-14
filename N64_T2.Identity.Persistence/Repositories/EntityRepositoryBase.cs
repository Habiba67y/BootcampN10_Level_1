using Microsoft.EntityFrameworkCore;
using N64_T2.Identity.DoMain.Common;
using N64_T2.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;
using System.Security.Principal;

namespace N64_T2.Identity.Persistence.Repositories;

public abstract class EntityRepositoryBase<TIEntity> : IEntityReposityBase<TIEntity> where TIEntity : class, IEntity
{
    private readonly DbContext _dbContext;

    public EntityRepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IQueryable<TIEntity> Get(Expression<Func<TIEntity, bool>>? predicate = default, bool asNoTracking = false)
    {
        var initialQuery = _dbContext.Set<TIEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if(asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    public ValueTask<TIEntity?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default)
    {
        var initialQuery = _dbContext.Set<TIEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        var entity = initialQuery.FirstOrDefaultAsync(e => e.Id == id, cancellationToken: cancellation);

        return new(entity);
    }
     
    public async ValueTask<IList<TIEntity>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default)
    {
        var initialQuery = _dbContext.Set<TIEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        var entities = await initialQuery.Where(entity => ids.Contains(entity.Id))
            .ToListAsync(cancellationToken: cancellation);
        return entities;
    }

    public async ValueTask<TIEntity> CreateAsync(TIEntity entity, bool saveChanges = true, CancellationToken cancellation = default)
    {
        await _dbContext.Set<TIEntity>().AddAsync(entity, cancellation);

        if(saveChanges)
            await _dbContext.SaveChangesAsync(cancellation);

        return entity;
    }

    public async ValueTask<TIEntity> UpdateAsync(TIEntity entity, bool saveChanges = true, CancellationToken cancellation = default)
    {
        _dbContext.Set<TIEntity>().Update(entity);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellation);

        return entity;
    }

    public async ValueTask<TIEntity?> DeleteAsync(TIEntity entity, bool saveChanges = true, CancellationToken cancellation = default)
    {
        _dbContext.Set<TIEntity>().Remove(entity);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellation);

        return entity;
    }

    public async ValueTask<TIEntity?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    {
        var entity = await GetByIdAsync(id) ?? throw new InvalidOperationException();

        return await DeleteAsync(entity, saveChanges, cancellation);
    }
}
