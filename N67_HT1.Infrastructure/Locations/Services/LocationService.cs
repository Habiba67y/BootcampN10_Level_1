using N67_HT1.Application.Locations.Servcises;
using N67_HT1.DoMain.Entites;
using N67_HT1.Persistence.DataContext;
using System.Linq.Expressions;

namespace N67_HT1.Infrastructure.Locations.Services;

public class LocationService : ILocationService
{
    private readonly IDbContext _dbContext;

    public LocationService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<Location> Get(Expression<Func<Location, bool>> predicate)
   => _dbContext.Locations.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<Location>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    => new(Get(location => ids.Contains(location.Id)).ToList());

    public async ValueTask<Location?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _dbContext.Locations.FindAsync(id, cancellationToken);

    public async ValueTask<Location> CreateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(location);

        await _dbContext.Locations.AddAsync(location);

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return location;
    }

    public async ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(location);

        var foundLocation = await GetByIdAsync(location.Id) ?? throw new InvalidOperationException("Location not found"); ;
        foundLocation.Type = location.Type;
        foundLocation.Name = location.Name;

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return foundLocation;
    }

    public async ValueTask<Location> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundLocation = await GetByIdAsync(id) ?? throw new InvalidOperationException("Location not found"); ;

        _dbContext.Locations.Remove(foundLocation);

        return foundLocation;
    }

    public ValueTask<Location> DeleteAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    => DeleteByIdAsync(location.Id, saveChanges, cancellationToken);

    private void Validate(Location location)
    {
        if (string.IsNullOrWhiteSpace(location.Name))
            throw new InvalidDataException("Invalid Location Name");

    }
}
