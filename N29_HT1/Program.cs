var usernames = new List<string>
{
    "1-username",
    "2-username",
    "3-username",
    "4-username"
};
var createFiles = usernames.Select(user => Task.Run(
    () =>
    {
        var fileStream = File.Create($"{user}.json");
        Console.WriteLine($"{user} uchun file yaratildi");
        return fileStream;
    }));
await Task.WhenAll( createFiles );
