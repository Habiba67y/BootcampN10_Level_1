using N53_HT1.Api.Data;
using N53_HT1.Api.Models;
using N53_HT1.Api.Services.Interfaces;
using System.Linq.Expressions;

namespace N53_HT1.Api.Services;

public class UserService : IUserService
{
    private readonly IDataContext _dataContext;

    public UserService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dataContext.Users.AddAsync(user, cancellationToken);

        if (saveChanges)
            await _dataContext.SaveChangesAsync();

        return user;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate) =>
        _dataContext.Users.Where(predicate.Compile()).AsQueryable();
    
    public async ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dataContext.Users.FindAsync(id, cancellationToken);
}
