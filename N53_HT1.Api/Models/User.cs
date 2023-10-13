using N53_HT1.Api.Common;

namespace N53_HT1.Api.Models;

public class User: Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
}
