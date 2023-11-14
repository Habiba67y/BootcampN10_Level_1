using N64_T2.Identity.DoMain.Common;
using N64_T2.Identity.DoMain.Enums;

namespace N64_T2.Identity.DoMain.Entities;

public class Role : IEntity
{
    public Guid Id { get; set; }
    public RoleType RoleType { get; set; }
    public bool IsDisabled { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime ModifiedTime { get; set;}
}
