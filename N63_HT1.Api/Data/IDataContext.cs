using FileBaseContext.Abstractions.Models.FileSet;
using N63_HT1.Api.Entities;

namespace N63_HT1.Api.Data;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<StorageFile, Guid> Files { get; }
    ValueTask SaveChangesAsync();
}
