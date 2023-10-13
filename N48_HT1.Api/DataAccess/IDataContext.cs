using FileBaseContext.Abstractions.Models.FileSet;
using N48_HT1.Api.Models;

namespace N48_HT1.Api.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Order, Guid> Orders { get; }

    ValueTask SaveChangesAsync();
}
