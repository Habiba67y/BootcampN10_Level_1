using N71_HT1.DoMain.Entities;
using System.Linq.Expressions;

namespace N71_HT1.Persistence.Repositories.Interfaces;

public interface ICommentRepository
{
    IQueryable<Comment> Get(Expression<Func<Comment, bool>>? predicate = default, bool asNoTracking = false);
    ValueTask<Comment?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<IList<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<Comment> UpdateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<Comment?> DeleteAsync(Comment comment, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<Comment?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default);
}
