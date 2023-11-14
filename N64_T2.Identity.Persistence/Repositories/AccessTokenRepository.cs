using N64_T2.Identity.DoMain.Entities;
using N64_T2.Identity.Persistence.DataContexts;
using N64_T2.Identity.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace N64_T2.Identity.Persistence.Repositories;

public class AccessTokenRepository : EntityRepositoryBase<AccessToken>, IAccessTokenRepository
{
    public AccessTokenRepository(IdentityDbContext dbContext) : base(dbContext)
    {

    }
    public ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellation = default)
    => base.CreateAsync(accessToken, saveChanges, cancellation);

    public IQueryable<AccessToken> Get(Expression<Func<AccessToken, bool>>? predicate = default, bool asNoTracking = false)
    => base.Get(predicate, asNoTracking);

    public ValueTask<AccessToken?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellation = default)
    => base.GetByIdAsync(id, asNoTracking, cancellation);
}
