using N71_HT1.DoMain.Entities;
using System.Linq.Expressions;

namespace N71_HT1.Application.Common;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);
    ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<User?> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<User?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default);
}
