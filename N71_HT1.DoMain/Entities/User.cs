using N71_HT1.DoMain.Common;

namespace N71_HT1.DoMain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}