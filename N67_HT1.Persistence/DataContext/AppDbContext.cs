using Microsoft.EntityFrameworkCore;
using N67_HT1.DoMain.Entites;

namespace N67_HT1.Persistence.DataContext;

public class AppDbContext : DbContext, IDbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<UserSettings> UsersSettings => Set<UserSettings>();

    public DbSet<Location> Locations => Set <Location>();

    public DbSet<CourseStudent> StudentCourses => Set<CourseStudent>();

    public DbSet<Course> Courses => Set<Course>();

    public AppDbContext(DbContextOptions<DbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
