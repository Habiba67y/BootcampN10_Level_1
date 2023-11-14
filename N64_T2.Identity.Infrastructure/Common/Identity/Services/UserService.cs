using Microsoft.EntityFrameworkCore;
using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.DoMain.Entities;
using N64_T2.Identity.Persistence.DataContexts;
using N64_T2.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository userRepository)
    {
        _repository = userRepository;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    => _repository.Get(predicate, asNoTracking);

    public async ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
    => await _repository.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public async ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    => await _repository.GetByIdAsync(id, asNoTracking, cancellationToken);

    public async ValueTask<User?> GetByEmailAsync(string email, bool asNoTracking = false, CancellationToken cancellationToken = default)
    => await Get(asNoTracking: asNoTracking).SingleOrDefaultAsync(user => user.EmailAddress.Equals(email));

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        return await _repository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        return await _repository.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    => _repository.DeleteByIdAsync(id, saveChanges, cancellationToken);

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    => _repository.DeleteAsync(user, saveChanges, cancellationToken);

    private void Validate(User user)
    {
        if(string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
            throw new InvalidDataException("Invalid fullname");

        if (!Regex.IsMatch(user.EmailAddress, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            throw new InvalidDataException("Invalid email address");

        if (user.Age < 1)
            throw new InvalidDataException("Invalid age");
    }

}
