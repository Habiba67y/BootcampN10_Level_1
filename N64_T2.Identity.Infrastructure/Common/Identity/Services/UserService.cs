﻿using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.DoMain.Entities;
using N64_T2.Identity.Persistence.DataContexts;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace N64_T2.Identity.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly IDbContext _dbContext;

    public UserService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
    => _dbContext.Users.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    => new(Get(user => ids.Contains(user.Id)).ToList());

    public async ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _dbContext.Users.FindAsync(id, cancellationToken) ?? throw new InvalidOperationException("User not found");

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        await _dbContext.Users.AddAsync(user);

        if(saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(user);

        var foundUser = await GetByIdAsync(user.Id);

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.EmailAddress = user.EmailAddress;
        foundUser.Password = user.Password;
        foundUser.Age = user.Age;

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return foundUser;
    }

    public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = await GetByIdAsync(id);

        _dbContext.Users.Remove(foundUser);

        return foundUser;
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    => DeleteAsync(user.Id, saveChanges, cancellationToken);

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
