namespace N67_HT1.DoMain.Entites;

public class CourseStudent
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; }
    public virtual User Student { get; set; }
}
