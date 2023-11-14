using N71_HT1.DoMain.Common;

namespace N71_HT1.DoMain.Entities;

public class Blog : IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid BloggerId { get; set; }
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
