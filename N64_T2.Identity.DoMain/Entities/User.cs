using N64_T2.Identity.DoMain.Common;

namespace N64_T2.Identity.DoMain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    public string PasswordHash { get; set; }
    public bool IsEmailAddressVerified { get; set; }
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }
}
