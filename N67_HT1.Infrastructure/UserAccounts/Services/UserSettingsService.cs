using N67_HT1.Application.UserAccounts.Services;
using N67_HT1.DoMain.Entites;
using N67_HT1.Persistence.DataContext;
using System.Linq.Expressions;

namespace N67_HT1.Infrastructure.UserAccounts.Services;

public class UserSettingsService : IUserSettingsService
{
    private readonly IDbContext _dbContext;

    public UserSettingsService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<UserSettings> Get(Expression<Func<UserSettings, bool>> predicate)
   => _dbContext.UsersSettings.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<UserSettings>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    => new(Get(userSettings => ids.Contains(userSettings.Id)).ToList());

    public async ValueTask<UserSettings?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _dbContext.UsersSettings.FindAsync(id, cancellationToken);

    public async ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dbContext.UsersSettings.AddAsync(userSettings);

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return userSettings;
    }

    public async ValueTask<UserSettings> UpdateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUserSettings = await GetByIdAsync(userSettings.Id) ?? throw new InvalidOperationException("UserSettings not found"); ;

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return foundUserSettings;
    }

    public async ValueTask<UserSettings> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUserSettings = await GetByIdAsync(id) ?? throw new InvalidOperationException("UserSettings not found"); ;

        _dbContext.UsersSettings.Remove(foundUserSettings);

        return foundUserSettings;
    }

    public ValueTask<UserSettings> DeleteAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    => DeleteByIdAsync(userSettings.Id, saveChanges, cancellationToken);

}
