using N71_HT1.DoMain.Common;

namespace N71_HT1.DoMain.Entities;

public class Comment : IEntity
{
    public Guid Id { get; set; }
    public string Commentary { get; set; }
    public Guid BlogId { get; set; }
}
