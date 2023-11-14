using N71_HT1.DoMain.Entities;
using System.Linq.Expressions;

namespace N71_HT1.Persistence.Repositories.Interfaces;

public interface IBlogRepository
{
    IQueryable<Blog> Get(Expression<Func<Blog, bool>>? predicate = default, bool asNoTracking = false);
    ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<IList<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<Blog?> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<Blog?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default);
}
