using N67_HT1.DoMain.Entites;
using System.Linq.Expressions;

namespace N67_HT1.Application.UserAccounts.Services;

public interface IUserSettingsService
{
    IQueryable<UserSettings> Get(Expression<Func<UserSettings, bool>>? predicate = null);

    ValueTask<UserSettings?> GetByIdAsync(Guid settingsId, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> CreateAsync(UserSettings settings, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> UpdateAsync(UserSettings settings, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> DeleteAsync(UserSettings settings, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserSettings> DeleteByIdAsync(Guid settingsId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
