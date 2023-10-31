namespace N66_T1.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid AuthorId { get; set; }
    public virtual Author Author { get; set; }
}
