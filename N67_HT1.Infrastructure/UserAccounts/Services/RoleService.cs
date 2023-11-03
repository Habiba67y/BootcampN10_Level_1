using N67_HT1.Application.UserAccounts.Services;
using N67_HT1.DoMain.Entites;
using N67_HT1.Persistence.DataContext;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace N67_HT1.Infrastructure.UserAccounts.Services;

public class RoleService : IRoleService
{
    private readonly IDbContext _dbContext;

    public RoleService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<Role> Get(Expression<Func<Role, bool>> predicate)
   => _dbContext.Roles.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<Role>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    => new(Get(role => ids.Contains(role.Id)).ToList());

    public async ValueTask<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _dbContext.Roles.FindAsync(id, cancellationToken);

    public async ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(role);

        await _dbContext.Roles.AddAsync(role);

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return role;
    }

    public async ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(role);

        var foundRole = await GetByIdAsync(role.Id) ?? throw new InvalidOperationException("Role not found"); ;

        foundRole.Name = role.Name;

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return foundRole;
    }

    public async ValueTask<Role> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundRole = await GetByIdAsync(id) ?? throw new InvalidOperationException("Role not found"); ;

        _dbContext.Roles.Remove(foundRole);

        return foundRole;
    }

    public ValueTask<Role> DeleteAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default)
    => DeleteByIdAsync(role.Id, saveChanges, cancellationToken);

    private void Validate(Role role)
    {
        if (string.IsNullOrWhiteSpace(role.Name))
            throw new InvalidDataException("Invalid Role Name");

    }
}
