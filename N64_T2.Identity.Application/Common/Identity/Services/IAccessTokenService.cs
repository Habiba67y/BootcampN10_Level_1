using N64_T2.Identity.DoMain.Entities;
using System.Linq.Expressions;

namespace N64_T2.Identity.Application.Common.Identity.Services;

public interface IAccessTokenService
{
    IQueryable<AccessToken> Get(Expression<Func<AccessToken, bool>>? predicate= default, bool asNoTracking = false);

    ValueTask<AccessToken?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, bool asNoTracking = false);
    ValueTask<AccessToken> CreateAsync(Guid userId, string token, bool saveChanges = true, CancellationToken cancellationToken = default);
}
