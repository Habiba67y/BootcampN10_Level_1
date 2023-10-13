using N53_HT1.Api.Common;

namespace N53_HT1.Api.Models;

public class Bonus : Auditable
{
    public Guid UserId { get; set; }
    public int Amount { get; set; }
}
