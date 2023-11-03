using N67_HT1.Application.Courses.Services;
using N67_HT1.DoMain.Entites;
using N67_HT1.Persistence.DataContext;
using System.Linq.Expressions;

namespace N67_HT1.Infrastructure.Courses.Services;

public class CourseService : ICourseService
{
    private readonly IDbContext _dbContext;

    public CourseService(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<Course> Get(Expression<Func<Course, bool>> predicate)
   => _dbContext.Courses.Where(predicate.Compile()).AsQueryable();

    public ValueTask<ICollection<Course>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    => new(Get(course => ids.Contains(course.Id)).ToList());

    public async ValueTask<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    => await _dbContext.Courses.FindAsync(id, cancellationToken);

    public async ValueTask<Course> CreateAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(course);

        await _dbContext.Courses.AddAsync(course);

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return course;
    }

    public async ValueTask<Course> UpdateAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        Validate(course);

        var foundCourse = await GetByIdAsync(course.Id) ?? throw new InvalidOperationException("Course not found"); ;

        foundCourse.Name = course.Name;
        foundCourse.Description = course.Description;

        if (saveChanges) await _dbContext.SaveChangesAsync(cancellationToken);

        return foundCourse;
    }

    public async ValueTask<Course> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundCourse = await GetByIdAsync(id) ?? throw new InvalidOperationException("Course not found"); ;

        _dbContext.Courses.Remove(foundCourse);

        return foundCourse;
    }

    public ValueTask<Course> DeleteAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default)
    => DeleteByIdAsync(course.Id, saveChanges, cancellationToken);

    private void Validate(Course course)
    {
        if (string.IsNullOrWhiteSpace(course.Name))
            throw new InvalidDataException("Invalid course Name");

        if (string.IsNullOrWhiteSpace(course.Description))
            throw new InvalidDataException("Invalid course Description");
    }
}
