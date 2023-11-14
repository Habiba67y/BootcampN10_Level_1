using N64_T2.Identity.DoMain.Common;
using System.Linq.Expressions;

namespace N64_T2.Identity.Persistence.Repositories.Interfaces;

public interface IEntityReposityBase<TIEntity> where TIEntity : class, IEntity
{
    IQueryable<TIEntity> Get(Expression<Func<TIEntity, bool>>? predicate = default, bool asNoTracking = false);
    ValueTask<TIEntity?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<IList<TIEntity>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<TIEntity> CreateAsync(TIEntity entity, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<TIEntity> UpdateAsync(TIEntity entity, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<TIEntity?> DeleteAsync(TIEntity entity, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<TIEntity?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default);
}
