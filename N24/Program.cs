using N24;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO.Pipes;

var People = new List<Person>()
{
    new Person(1, "Gishmat", 18),
    new Person(2, "Eshmat", 20),
};
var path = @"D:\Projects\BootcampN10_Level_1\N24\person.txt";
var json = JsonConvert.SerializeObject(People, Formatting.Indented);
using (StreamWriter writer = new StreamWriter(path))
{
    writer.Write(json);
}
//read
using (var reader = new StreamReader(path))
{
    Console.WriteLine();
    var people = JsonConvert.DeserializeObject<List<Person>>(reader.ReadToEnd());
    people.ForEach(Console.WriteLine);
}

//add
Console.Write("Name: ");
var name = Console.ReadLine();
Console.Write("Age: ");
var age = byte.Parse(Console.ReadLine());
People.Add(new Person(People.Last().Id + 1, name, age));
json = JsonConvert.SerializeObject(People, Formatting.Indented);
using (StreamWriter writer = new StreamWriter(path))
{
    writer.Write(json);
}

//delete
Console.Write("Id: ");
var id = int.Parse(Console.ReadLine());
var person = People.FirstOrDefault(p => p.Id==id);
if (person != null)
    People.Remove(person);
json = JsonConvert.SerializeObject(People, Formatting.Indented);
using (StreamWriter writer = new StreamWriter(path))
{
    writer.Write(json);
}