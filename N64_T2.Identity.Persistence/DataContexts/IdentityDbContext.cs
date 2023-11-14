using Microsoft.EntityFrameworkCore;
using N64_T2.Identity.DoMain.Entities;

namespace N64_T2.Identity.Persistence.DataContexts;

public class IdentityDbContext : DbContext
{
    public DbSet<AccessToken> AccessTokens => Set<AccessToken>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}
