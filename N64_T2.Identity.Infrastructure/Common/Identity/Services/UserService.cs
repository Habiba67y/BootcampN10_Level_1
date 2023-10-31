using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.DoMain.Entities;
using System.Linq.Expressions;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }


    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
