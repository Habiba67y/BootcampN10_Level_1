using N64_T2.Identity.DoMain.Common;

namespace N64_T2.Identity.DoMain.Entities;

public class AccessToken : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public string Token { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime CreatedTime { get; set; }
}
