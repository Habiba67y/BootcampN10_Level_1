public class BlogPost
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Tag { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
}

public class BlogManagaer
{
 //   public List<BlogPost> blogPosts { get; set; }
    public void Analyze(List<BlogPost> blogPost)
    {
        
    }
}