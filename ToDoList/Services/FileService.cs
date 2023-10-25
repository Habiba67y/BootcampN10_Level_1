using ToDoList.Services.Interfaces;

namespace ToDoList.Services;

public class FileService : IFileService
{
    private readonly string _folderName = "images";
    private readonly string _basePath;

    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _basePath = webHostEnvironment.WebRootPath;
    }
    public string FolderName => _folderName;

    public ValueTask<bool> DeleteAsync(string path)
    {
        
    }

    public async ValueTask<string> SaveAsync(IFormFile image)
    {
        var folderPath = Path.Combine(_basePath, _folderName);
        
        if (!Directory.Exists(_basePath))
            Directory.CreateDirectory(_basePath);
        if(!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        var stream = File.Create(image.FileName);
        await image.CopyToAsync(stream);
        stream.Close();

        return image.FileName;
    }
}
