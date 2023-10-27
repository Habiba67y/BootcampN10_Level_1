using Microsoft.Extensions.Options;
using N63_HT1.Models.Entities;
using N63_HT1.Models.Settings;
using N63_HT1.Services.Interfaces;

namespace N63_HT1.Services;

public class FileService : IFileService
{
    private readonly FileStorageSettings _fileStorgaeSettings;

    public FileService(IOptions<FileStorageSettings> options)
    {
        _fileStorgaeSettings = options.Value;
    }
    public ValueTask<Stream> UploadFileAsync(IFormFile file, StorageFile storageFile)
    {
        var path = _fileStorgaeSettings.UserProfileFilesPathPattern
            .Replace("{{UserId}}", storageFile.Id.ToString())
            .Replace("{{FileId}}", storageFile.Id.ToString());

        var stream = File.Open(path, FileMode.Open, FileAccess.Read);
        file.CopyTo(stream);
        
        return new(stream);
    }
}
