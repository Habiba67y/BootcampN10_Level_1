using N63_HT1.Api.Entities.Common;

namespace N63_HT1.Api.Entities;

public class StorageFile : Auditable
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string DirectoryPath { get; set; }
    public long Size { get; set; }
    public string Extension { get; set; }
}
