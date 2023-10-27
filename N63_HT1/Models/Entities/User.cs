using N63_HT1.Models.Entities.Common;

namespace N63_HT1.Models.Entities;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
}
