using N71_HT1.DoMain.Entities;
using N71_HT1.Persistence.DataContexts;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N71_HT1.Persistence.Repositories;

public class BlogRepository : EntityRepositoryBase<Blog>, IBlogRepository
{
    public BlogRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public IQueryable<Blog> Get(Expression<Func<Blog, bool>>? predicate = null, bool asNoTracking = false)
    => base.Get(predicate, asNoTracking);

    public ValueTask<Blog?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default)
    => base.GetByIdAsync(id, asNoTracking, cancellation);

    public ValueTask<IList<Blog>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default)
    => base.GetByIdsAsync(ids, asNoTracking, cancellation);

    public ValueTask<Blog> CreateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellation = default)
    => base.CreateAsync(blog, saveChanges, cancellation);

    public ValueTask<Blog> UpdateAsync(Blog blog, bool saveChanges = true, CancellationToken cancellation = default)
    => base.UpdateAsync(blog, saveChanges, cancellation);

    public ValueTask<Blog?> DeleteAsync(Blog blog, bool saveChanges = true, CancellationToken cancellation = default)
    => base.DeleteAsync(blog, saveChanges, cancellation);

    public ValueTask<Blog?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    => base.DeleteByIdAsync(id, saveChanges, cancellation);


}
