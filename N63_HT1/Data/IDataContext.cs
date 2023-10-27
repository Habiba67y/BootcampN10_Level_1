using FileBaseContext.Abstractions.Models.FileSet;
using N63_HT1.Models.Entities;

namespace N63_HT1.Data;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<StorageFile, Guid> Files { get; }
    ValueTask SaveChangesAsync();
}
