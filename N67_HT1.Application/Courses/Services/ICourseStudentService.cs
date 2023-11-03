using N67_HT1.DoMain.Entites;
using System.Linq.Expressions;

namespace N67_HT1.Application.Courses.Services;

public interface ICourseStudentService
{
    IQueryable<CourseStudent> Get(Expression<Func<CourseStudent, bool>>? predicate = null);

    ValueTask<CourseStudent?> GetByIdAsync(Guid studentCourseId, CancellationToken cancellationToken = default);

    ValueTask<CourseStudent> CreateAsync(CourseStudent studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<CourseStudent> UpdateAsync(CourseStudent studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<CourseStudent> DeleteAsync(CourseStudent studentCourse, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<CourseStudent> DeleteByIdAsync(Guid studentCourseId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
