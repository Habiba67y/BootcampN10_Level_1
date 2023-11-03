namespace N67_HT1.DoMain.Entites;

public class Course
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid TeacherId { get; set; }
    public virtual User Teacher { get; set; }
    public virtual ICollection<CourseStudent> CourseStudents { get; set; }
}
