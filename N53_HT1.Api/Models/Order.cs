using N53_HT1.Api.Common;

namespace N53_HT1.Api.Models;

public class Order : Auditable
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}
