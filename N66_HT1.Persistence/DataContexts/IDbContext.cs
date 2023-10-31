using Microsoft.EntityFrameworkCore;
using N66_HT1.DoMain.Entities;

namespace N66_HT1.Persistence.DataContexts;

public interface IDbContext
{
    DbSet<Author> Authors { get; }
    DbSet<Book> Books { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
