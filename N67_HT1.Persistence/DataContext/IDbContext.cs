using Microsoft.EntityFrameworkCore;
using N67_HT1.DoMain.Entites;
using Microsoft.EntityFrameworkCore;

namespace N67_HT1.Persistence.DataContext;

public interface IDbContext
{
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<UserSettings> UsersSettings { get; }
    DbSet<Location> Locations { get; }
    DbSet<CourseStudent> StudentCourses { get; }
    DbSet<Course> Courses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
