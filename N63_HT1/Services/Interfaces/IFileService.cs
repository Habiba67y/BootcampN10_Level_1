using N63_HT1.Models.Entities;

namespace N63_HT1.Services.Interfaces;

public interface IFileService
{
    ValueTask<Stream> UploadFileAsync(IFormFile file, StorageFile storageFile);
}
