using N33_T1;
using System.Text.Json;
using System.Text.Json.Nodes;

var fileName = $"file.json";
var folderName = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString());
var filePath = Path.Combine(folderName, fileName);
var json = new JsonFileManagementService();
var user = new User()
{
    Id = Guid.NewGuid(),
    Name = "qwerty"
};
await json.WriteAsync(filePath, JsonSerializer.Serialize(user));
Console.WriteLine(await json.ReadAsync(filePath));
Console.WriteLine(await json.ReadAsync<User>(filePath));