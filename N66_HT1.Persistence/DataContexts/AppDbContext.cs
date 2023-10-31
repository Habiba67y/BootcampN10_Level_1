using Microsoft.EntityFrameworkCore;
using N66_HT1.DoMain.Entities;

namespace N66_HT1.Persistence.DataContexts;

public class AppDbContext : DbContext, IDbContext
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MyFirstEfCoreApp;Username=postgres;Password=postgres");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasOne(book => book.Author).WithMany();
    }
}
