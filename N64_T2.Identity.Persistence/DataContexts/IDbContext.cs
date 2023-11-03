using Microsoft.EntityFrameworkCore;
using N64_T2.Identity.DoMain.Entities;

namespace N64_T2.Identity.Persistence.DataContexts;

public interface IDbContext
{
    DbSet<User> Users { get; }
    DbSet<Token> Tokens { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
