namespace N67_HT1.DoMain.Entites;

public class UserSettings
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
