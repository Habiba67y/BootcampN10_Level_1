using N63_HT1.Models.Entities;
using System.Linq.Expressions;

namespace N63_HT1.Services.Interfaces;

public interface IStorageFileService
{
    IQueryable<StorageFile> Get(Expression<Func<StorageFile, bool>> predicate);

    ValueTask<ICollection<StorageFile>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

    ValueTask<StorageFile?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<StorageFile> CreateAsync(StorageFile storageFile, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<StorageFile> UpdateAsync(StorageFile storageFile, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<StorageFile> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<StorageFile> DeleteAsync(StorageFile storageFile, bool saveChanges = true, CancellationToken cancellationToken = default);
}
