using N67_HT1.DoMain.Entites;
using System.Linq.Expressions;

namespace N67_HT1.Application.Courses.Services;

public interface ICourseService
{
    IQueryable<Course> Get(Expression<Func<Course, bool>>? predicate = null);

    ValueTask<Course?> GetByIdAsync(Guid courseId, CancellationToken cancellationToken = default);

    ValueTask<Course> CreateAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Course> UpdateAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Course> DeleteAsync(Course course, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<  Course> DeleteByIdAsync(Guid courseId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
