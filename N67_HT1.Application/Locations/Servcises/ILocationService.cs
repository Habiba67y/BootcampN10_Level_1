using N67_HT1.DoMain.Entites;
using System.Linq.Expressions;

namespace N67_HT1.Application.Locations.Servcises;

public interface ILocationService
{
    IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = null);

    ValueTask<Location?> GetByIdAsync(Guid locationId, CancellationToken cancellationToken = default);

    ValueTask<Location> CreateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Location> DeleteAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Location> DeleteByIdAsync(Guid locationId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
