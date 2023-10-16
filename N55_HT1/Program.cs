using N55_HT1;

var Amount = FileService.getAmountOfEntries();
var size = FileService.GetSizeOfFiles();
Console.WriteLine($"Count of\nEntries - {Amount.EntiresCount}\nFolders - {Amount.FoldersCount}\nFiles - {Amount.FilesCount}");
Console.WriteLine($"\nAll size of files - {size.AllSize}\nMax size of files - {size.MaxSize}");