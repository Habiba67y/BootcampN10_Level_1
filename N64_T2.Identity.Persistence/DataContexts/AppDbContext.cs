using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using N64_T2.Identity.Application.Common.Settings;
using N64_T2.Identity.DoMain.Entities;

namespace N64_T2.Identity.Persistence.DataContexts;

public class AppDbContext : DbContext, IDbContext
{
    private readonly DbContextSettings _settings;

    public AppDbContext(IOptions<DbContextSettings> options)
    {
        _settings = options.Value;
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Token> Tokens => Set<Token>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(_settings.Connection);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Token>().HasOne(token => token.User).WithMany();
    }
}
