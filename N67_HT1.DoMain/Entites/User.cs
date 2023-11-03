using N67_HT1.DoMain.Enums;

namespace N67_HT1.DoMain.Entites;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public UserRole Role { get; set; }
    public Guid LocationId { get; set; }
    public virtual UserSettings UserSettings { get; set; }
    public virtual Location Location { get; set; }
    public virtual ICollection<Course> TeacherCourses { get; set; }
    public virtual ICollection<CourseStudent> CourseStudents { get; set; }
}
