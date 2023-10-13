using N53_HT1.Api.Models;
using System.Linq.Expressions;

namespace N53_HT1.Api.Services.Interfaces;

public interface IBonusService
{
    IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate);

    ValueTask<Bonus?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<Bonus> CreateAsync(Bonus bonus, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Bonus> UpdateAsync(Bonus bonus, bool saveChanges = true, CancellationToken cancellationToken = default);
}
