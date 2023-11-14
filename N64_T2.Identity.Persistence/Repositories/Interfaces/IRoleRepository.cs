using N64_T2.Identity.DoMain.Entities;
using System.Linq.Expressions;

namespace N64_T2.Identity.Persistence.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false);
    ValueTask<Role?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<IList<Role>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default);
    ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<Role?> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellation = default);
    ValueTask<Role?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default);
}
