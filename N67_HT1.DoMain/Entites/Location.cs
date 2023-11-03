using N67_HT1.DoMain.Enums;

namespace N67_HT1.DoMain.Entites;

public class Location
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public LocationType Type { get; set; }
    public Guid? ParentId { get; set; }
    public ICollection<Guid> UsersId { get; set; }
    public virtual ICollection<User> Users { get; set; }
}
