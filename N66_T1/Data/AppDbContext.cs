using Microsoft.EntityFrameworkCore;
using N66_T1.Models;

namespace N66_T1.Data;

public class AppDbContext : DbContext
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
