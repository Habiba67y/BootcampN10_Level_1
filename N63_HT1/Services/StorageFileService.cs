using N63_HT1.Data;
using N63_HT1.Models.Entities;
using N63_HT1.Services.Interfaces;
using System.Linq.Expressions;

namespace N63_HT1.Services;

public class StorageFileService : IStorageFileService
{
    private readonly IDataContext _dataContext;

    public StorageFileService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async ValueTask<StorageFile> CreateAsync(StorageFile storageFile, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dataContext.Files.AddAsync(storageFile, cancellationToken);

        if (saveChanges)
            await _dataContext.SaveChangesAsync();

        return storageFile;
    }

    public async ValueTask<StorageFile> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundFile = await GetByIdAsync(id);

        await _dataContext.Files.RemoveAsync(foundFile, cancellationToken);

        if (saveChanges)
            await _dataContext.SaveChangesAsync();

        return foundFile;
    }

    public async ValueTask<StorageFile> DeleteAsync(StorageFile storageFile, bool saveChanges = true, CancellationToken cancellationToken = default)
    => await DeleteAsync(storageFile.Id, saveChanges, cancellationToken);

    public IQueryable<StorageFile> Get(Expression<Func<StorageFile, bool>> predicate)
    => _dataContext.Files.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<StorageFile>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    => new(Get(file => ids.Contains(file.Id)).ToList());

    public async ValueTask<StorageFile?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _dataContext.Files.FindAsync(id) ?? throw new InvalidOperationException("File not found");

    public async ValueTask<StorageFile> UpdateAsync(StorageFile storageFile, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundFile = await GetByIdAsync(storageFile.Id);

        foundFile.UserId = storageFile.UserId;
        foundFile.Name = storageFile.Name;
        foundFile.Size = storageFile.Size;
        foundFile.Extension = storageFile.Extension;

        await _dataContext.Files.UpdateAsync(foundFile, cancellationToken);

        if (saveChanges)
            await _dataContext.SaveChangesAsync();

        return foundFile;
    }
}
