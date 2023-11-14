using N64_T2.Identity.DoMain.Entities;
using N64_T2.Identity.Persistence.DataContexts;
using N64_T2.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N64_T2.Identity.Persistence.Repositories;

public class RoleRepository : EntityRepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(IdentityDbContext dbContext) : base(dbContext)
    {

    }
    public IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false)
    => base.Get(predicate, asNoTracking);

    public ValueTask<Role?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellation = default)
    => base.GetByIdAsync(id, asNoTracking, cancellation);

    public ValueTask<IList<Role>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default)
    => base.GetByIdsAsync(ids, asNoTracking, cancellation);


    public ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellation = default)
    => base.CreateAsync(role, saveChanges, cancellation);

    public async ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellation = default)
    {
        var foundRole = await GetByIdAsync(role.Id, cancellation: cancellation);

        foundRole.RoleType = role.RoleType;
        foundRole.IsDisabled = role.IsDisabled;

        return await base.UpdateAsync(role, saveChanges, cancellation);
    }

    public ValueTask<Role?> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellation = default)
    => base.DeleteAsync(role, saveChanges, cancellation);

    public ValueTask<Role?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    => base.DeleteByIdAsync(id, saveChanges, cancellation);
}    

