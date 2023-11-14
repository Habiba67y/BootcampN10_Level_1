using Microsoft.EntityFrameworkCore;
using N71_HT1.Application.Common;
using N71_HT1.DoMain.Entities;
using N71_HT1.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace N71_HT1.Infrastructure.Common;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null, bool asNoTracking = false)
    => _repository.Get(predicate, asNoTracking).Include(blogger => blogger.Blogs).ThenInclude(blog => blog.Comments);

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default)
    => _repository.GetByIdAsync(id, asNoTracking, cancellation);

    public ValueTask<IList<User>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellation = default)
    => _repository.GetByIdsAsync(ids, asNoTracking, cancellation);

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    {
        Validate(user);

        return _repository.CreateAsync(user, saveChanges, cancellation);
    }
    
    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    {
        Validate(user);

        var foundUser = await _repository.UpdateAsync(user, saveChanges, cancellation);

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.EmailAddress = user.EmailAddress;
        foundUser.Password = user.Password;
        foundUser.Age = user.Age;

        return foundUser;
    }

    private void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new InvalidDataException("Invalid fullname");

        if (!Regex.IsMatch(user.EmailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            throw new InvalidDataException("Invalid email address");

        if (user.Password.Length < 8)
            throw new InvalidDataException("Invalid password");

        if (user.Age < 1)
            throw new InvalidDataException("Invalid age");
    }

    public ValueTask<User?> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellation = default)
    => _repository.DeleteAsync(user, saveChanges, cancellation);

    public ValueTask<User?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellation = default)
    => _repository.DeleteByIdAsync(id, saveChanges, cancellation);
}
