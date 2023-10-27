using FileBaseContext.Abstractions.Models.Entity;

namespace N63_HT1.Api.Entities.Common;

public class Auditable : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
}
