using N63_HT1.Data;
using N63_HT1.Models.Entities;
using N63_HT1.Services.Interfaces;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace N63_HT1.Services;

public class UserService : IUserService
{
    private readonly IDataContext _dataContext;

    public UserService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate) =>
        _dataContext.Users.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        var users = _dataContext.Users.Where(user => ids.Contains(user.Id));
        return new ValueTask<ICollection<User>>(users.ToList());
    }

    public async ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await _dataContext.Users.FindAsync(id, cancellationToken);

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);
        await _dataContext.Users.AddAsync(user, cancellationToken);

        if (saveChanges)
            await _dataContext.SaveChangesAsync();

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        var foundUser = await GetByIdAsync(user.Id) ?? throw new InvalidOperationException("User not found");

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.EmailAddress = user.EmailAddress;
        foundUser.Password = user.Password;
        foundUser.Age = user.Age;

        await _dataContext.Users.UpdateAsync(foundUser, cancellationToken);

        if (saveChanges)
            await _dataContext.SaveChangesAsync();

        return foundUser;
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync(user.Id, saveChanges, cancellationToken);
    }

    public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = await GetByIdAsync(id) ?? throw new InvalidOperationException("User not found");

        await _dataContext.Users.RemoveAsync(foundUser, cancellationToken);
        if (saveChanges)
            await _dataContext.SaveChangesAsync();

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
}

