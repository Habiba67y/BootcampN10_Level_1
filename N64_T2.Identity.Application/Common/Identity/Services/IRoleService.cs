using N64_T2.Identity.DoMain.Entities;
using N64_T2.Identity.DoMain.Enums;
using System.Linq.Expressions;

namespace N64_T2.Identity.Application.Common.Identity.Services;

public interface IRoleService
{
    IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<ICollection<Role>> GetAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Role?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);
    ValueTask<Role?> GetByTypeAsync(RoleType roleValue, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);
}
