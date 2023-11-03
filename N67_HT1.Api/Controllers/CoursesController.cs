using Microsoft.AspNetCore.Mvc;
using N67_HT1.Application.Courses.Services;
using N67_HT1.DoMain.Entites;

namespace N67_HT1.Api.Controllers;
[ApiController]
[Route("api/[controller]")]

public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly ICourseStudentService _studentCourseService;

    public CoursesController
        (
        ICourseService courseService,
        ICourseStudentService studentCourseService
        )
    {
        _courseService = courseService;
        _studentCourseService = studentCourseService;
    }

    [HttpGet]
    public IActionResult GetCourses()
    {
        var data = _courseService.Get(course => true);

        return data.Any() ? Ok(data) : NotFound();
    }

    [HttpGet("{courseId:guid}")]
    public async ValueTask<IActionResult> GetCourse([FromRoute] Guid courseId)
    {
        var result = await _courseService.GetByIdAsync(courseId);

        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateCourse([FromBody] Course course)
    {
        var result = await _courseService.CreateAsync(course);

        return CreatedAtAction(nameof(GetCourse), new { CourseId = result.Id }, result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateCourse([FromBody] Course course)
    {
        await _courseService.UpdateAsync(course);

        return NoContent();
    }

    [HttpDelete("{courseId:guid}")]
    public async ValueTask<IActionResult> DeleteCourse([FromRoute] Guid courseId)
    {
        await _courseService.DeleteByIdAsync(courseId);

        return NoContent();
    }

    [HttpGet("studentCourses")]
    public IActionResult GetStudentCourses()
    {
        var data = _studentCourseService.Get(course => true);

        return data.Any() ? Ok(data) : NotFound();
    }

    [HttpGet("studentCourses/{studentCourseId:guid}")]
    public async ValueTask<IActionResult> GetStudentCourse([FromRoute] Guid studentCourseId)
    {
        var result = await _studentCourseService.GetByIdAsync(studentCourseId);

        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost("studentCourses")]
    public async ValueTask<IActionResult> CreateStudentCourse([FromBody] CourseStudent studentCourse)
    {
        var result = await _studentCourseService.CreateAsync(studentCourse);

        return CreatedAtAction(nameof(GetCourse), new { StudentCourseId = result.Id }, result);
    }

    [HttpPut("studentCourses")]
    public async ValueTask<IActionResult> UpdateStudentCourse([FromBody] CourseStudent studentCourse)
    {
        await _studentCourseService.UpdateAsync(studentCourse);

        return NoContent();
    }

    [HttpDelete("studentCourses/{studentCourseId:guid}")]
    public async ValueTask<IActionResult> DeleteStudentCourse([FromRoute] Guid studentCourseId)
    {
        await _studentCourseService.DeleteByIdAsync(studentCourseId);

        return NoContent();
    }
}
