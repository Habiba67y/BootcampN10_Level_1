using FileBaseContext.Abstractions.Models.Entity;

namespace N48_HT1.Api.Models
{
    public class Order: IFileSetEntity<Guid>
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public Guid UserId { get; set; }
    }
}
