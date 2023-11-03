using N67_HT1.Application.Courses.Services;
using N67_HT1.DoMain.Entites;
using N67_HT1.Persistence.DataContext;
using System.Linq.Expressions;

namespace N67_HT1.Infrastructure.Courses.Services;

public class CourseStudentService : ICourseStudentService
{
    private readonly IDbContext _dbContext;

    public CourseStudentService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<CourseStudent> Get(Expression<Func<CourseStudent, bool>> predicate)
   => _dbContext.StudentCourses.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<CourseStudent>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    => new(Get(studentCourse => ids.Contains(studentCourse.Id)).ToList());

    public async ValueTask<CourseStudent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _dbContext.StudentCourses.FindAsync(id, cancellationToken);

    public async ValueTask<CourseStudent> CreateAsync(CourseStudent studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dbContext.StudentCourses.AddAsync(studentCourse);

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return studentCourse;
    }

    public async ValueTask<CourseStudent> UpdateAsync(CourseStudent studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundCourse = await GetByIdAsync(studentCourse.Id)
            ?? throw new InvalidOperationException("Student Course not found"); ;

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return foundCourse;
    }

    public async ValueTask<CourseStudent> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundCourse = await GetByIdAsync(id) ?? throw new InvalidOperationException("Student Course not found"); ;

        _dbContext.StudentCourses.Remove(foundCourse);

        return foundCourse;
    }

    public ValueTask<CourseStudent> DeleteAsync(CourseStudent studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default)
    => DeleteByIdAsync(studentCourse.Id, saveChanges, cancellationToken);

}
