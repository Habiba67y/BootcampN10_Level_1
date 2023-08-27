using N30_HT1;

var fileNames = new List<string>
{
    "document1.txt",
    "document2.txt",
    "document3.txt",
    "document4.txt",
    "document5.txt",
    "document6.txt",
    "document7.txt",
    "document8.txt",
    "document9.txt",
    "document10.txt",
};
var analyze = fileNames.Select(async fileName =>
{
    var folderName = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString());
    var filePath = Path.Combine(folderName, fileName);
    var documentAnalyizer = new DocumentAnalyzer();
    Console.WriteLine("Score: " + await documentAnalyizer.AnalyzeAsync(filePath));
    Console.WriteLine("\n");
});
await Task.WhenAll(analyze);