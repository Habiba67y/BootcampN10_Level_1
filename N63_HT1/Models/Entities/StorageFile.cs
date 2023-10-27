using N63_HT1.Models.Entities.Common;

namespace N63_HT1.Models.Entities;

public class StorageFile : Auditable
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public long Size { get; set; }
    public string Extension { get; set; }
}
