using Microsoft.EntityFrameworkCore;
using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.DoMain.Entities;
using N64_T2.Identity.DoMain.Enums;
using N64_T2.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false)
    => _roleRepository.Get(predicate, asNoTracking);

    public async ValueTask<ICollection<Role>> GetAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    => await _roleRepository.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public ValueTask<Role?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    => _roleRepository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public async ValueTask<Role?> GetByTypeAsync(RoleType roleValue, bool asNoTracking = false, CancellationToken cancellationToken = default)
    => await Get(asNoTracking: asNoTracking).SingleOrDefaultAsync(role => role.RoleType == roleValue, cancellationToken);

    public async ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    => await _roleRepository.CreateAsync(role, saveChanges, cancellationToken);

    public async ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    => await _roleRepository.UpdateAsync(role, saveChanges, cancellationToken);

    public async ValueTask<Role> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    => await _roleRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);

    public ValueTask<Role> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    => DeleteAsync(role.Id, saveChanges, cancellationToken);

}
