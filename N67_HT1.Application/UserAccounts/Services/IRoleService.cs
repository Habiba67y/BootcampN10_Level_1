using N67_HT1.DoMain.Entites;
using System.Linq.Expressions;

namespace N67_HT1.Application.UserAccounts.Services;

public interface IRoleService
{
    IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = null);

    ValueTask<Role?> GetByIdAsync(Guid roleId, CancellationToken cancellationToken = default);

    ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> DeleteByIdAsync(Guid roleId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
