using N53_HT1.Api.Models;
using System.Linq.Expressions;

namespace N53_HT1.Api.Services.Interfaces;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}  

