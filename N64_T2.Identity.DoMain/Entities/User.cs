namespace N64_T2.Identity.DoMain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public bool IsEmailAddressVerified { get; set; }
}
