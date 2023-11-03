namespace N64_T2.Identity.DoMain.Entities;

public class Token
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public string Name { get; set; }
}
