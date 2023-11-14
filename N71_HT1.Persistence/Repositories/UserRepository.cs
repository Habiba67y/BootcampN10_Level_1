using N71_HT1.DoMain.Entities;
using N71_HT1.Persistence.DataContexts;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N71_HT1.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User>,  IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null, bool asNoTracking = false)
    => base.Get(predicate, asNoTracking);

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default)
    => base.GetByIdAsync(id, asNoTracking, cancellation);

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default)
    => base.GetByIdsAsync(ids, asNoTracking, cancellation);

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    => base.CreateAsync(user, saveChanges, cancellation);
    
    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    => base.UpdateAsync(user, saveChanges, cancellation);
    
    public ValueTask<User?> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    => base.DeleteAsync(user, saveChanges, cancellation);

    public ValueTask<User?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    => base.DeleteByIdAsync(id, saveChanges, cancellation);

}
