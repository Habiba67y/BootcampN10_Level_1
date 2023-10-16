using System.Formats.Tar;

namespace N55_HT1;

public static class FileService
{
    public static (int EntiresCount, int FoldersCount, int FilesCount) getAmountOfEntries()
    {
        return (Directory.EnumerateFileSystemEntries(Directory.GetCurrentDirectory()).Count(), 
            Directory.GetDirectories(Directory.GetCurrentDirectory()).Count(),
            Directory.GetFiles(Directory.GetCurrentDirectory()).Count());
    }

    public static (long AllSize, long MaxSize) GetSizeOfFiles()
    {
        var files = Directory.GetFiles(Directory.GetCurrentDirectory()).AsQueryable();
        return (files.Sum(f => new FileInfo(f).Length), files.Max(f => new FileInfo(f).Length));
    }
}
