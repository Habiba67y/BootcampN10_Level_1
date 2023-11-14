using N71_HT1.DoMain.Entities;
using N71_HT1.Persistence.DataContexts;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N71_HT1.Persistence.Repositories;

public class CommentRepository : EntityRepositoryBase<Comment>, ICommentRepository
{
    public CommentRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public IQueryable<Comment> Get(Expression<Func<Comment, bool>>? predicate = null, bool asNoTracking = false)
    => base.Get(predicate, asNoTracking);

    public ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default)
    => base.GetByIdAsync(id, asNoTracking, cancellation);

    public ValueTask<IList<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default)
    => base.GetByIdsAsync(ids, asNoTracking, cancellation);

    public ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellation = default)
    => base.CreateAsync(comment, saveChanges, cancellation);

    public ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellation = default)
    => base.UpdateAsync(comment, saveChanges, cancellation);

    public ValueTask<Comment?> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellation = default)
    => base.DeleteAsync(comment, saveChanges, cancellation);

    public ValueTask<Comment?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    => base.DeleteByIdAsync(id, saveChanges, cancellation);


}
