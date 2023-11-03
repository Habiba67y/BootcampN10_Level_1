using N67_HT1.Application.UserAccounts.Services;
using N67_HT1.DoMain.Entites;
using N67_HT1.Persistence.DataContext;
using System.Data;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace N67_HT1.Infrastructure.UserAccounts.Services;

public class UserServices : IUserService
{
    private readonly IDbContext _dbContext;

    public UserServices(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
   => _dbContext.Users.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    => new(Get(user => ids.Contains(user.Id)).ToList());

    public async ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _dbContext.Users.FindAsync(id, cancellationToken);

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        user.Id = Guid.Empty;
        await _dbContext.Users.AddAsync(user);

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        var foundUser = await GetByIdAsync(user.Id) ?? throw new InvalidOperationException("User not found"); ;

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.EmailAddress = user.EmailAddress;
        foundUser.Role = user.Role;

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return foundUser;
    }

    public async ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = await GetByIdAsync(id) ?? throw new InvalidOperationException("User not found"); ;

        _dbContext.Users.Remove(foundUser);

        return foundUser;
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    => DeleteByIdAsync(user.Id, saveChanges, cancellationToken);

    private void Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new InvalidDataException("Invalid fullname");

        if (!Regex.IsMatch(user.EmailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            throw new InvalidDataException("Invalid email address");
    }
}
