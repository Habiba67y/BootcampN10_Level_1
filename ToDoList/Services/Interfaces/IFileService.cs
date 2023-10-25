namespace ToDoList.Services.Interfaces;

public interface IFileService
{
    public string FolderName { get; }
    ValueTask<string> SaveAsync(IFormFile image);
    ValueTask<bool> DeleteAsync(string path);
}
