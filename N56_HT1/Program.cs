using Bogus;
using N56_HT1.Models;

var absolutePath = "D:\\Projects\\BootcampN10_Level_1\\N56_HT1\\bin\\Debug\\net7.0\\Storage\\User";
var userfaker = new Faker<User>()
    .RuleFor(u => u.Id, Guid.NewGuid)
    .RuleFor(u => u.FirstName, f => f.Person.FirstName)
    .RuleFor(u => u.LastName, f => f.Person.LastName)
    .RuleFor(u => u.EmailAddress, f => f.Person.Email);
var users = userfaker.Generate(10);
foreach (var user in users)
{
    var profilePath = Path.Combine(absolutePath, $"{user.Id}\\Profile");
    var resumePath = Path.Combine(absolutePath, $"{user.Id}\\Resume");
    File.Create(Path.Combine(profilePath, "file1.jpg"));
    File.Create(Path.Combine(profilePath, "file2.jpg"));
    File.Create(Path.Combine(profilePath, "file3.txt"));

    File.Create(Path.Combine(resumePath, "file1."));
}
