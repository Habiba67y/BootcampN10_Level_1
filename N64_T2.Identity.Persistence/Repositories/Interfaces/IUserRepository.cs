using N64_T2.Identity.DoMain.Entities;
using System.Linq.Expressions;

namespace N64_T2.Identity.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);
    ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<User?> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<User?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default);
}
