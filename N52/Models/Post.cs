namespace N52.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Topic> Topics { get; set; }
    public Post(string title, string description, List<Topic> topics)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Topics = topics;
    }
}
