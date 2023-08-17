using N25;
using System.Net;
using System.Text.Json;

var savePath = @"D:\Projects\BootcampN10_Level_1\N25\AllCountries.txt";
var jsonFile = File.ReadAllText(savePath);
var result = JsonSerializer.Deserialize<List<Country>>(jsonFile);
var filters = Console.ReadLine();
var r = result.Where(item => item.Region.Contains(filters, StringComparison.OrdinalIgnoreCase)).ToList();
foreach (var item in r)
{
    Console.WriteLine($"{item.Region} | {item.Name.Common}");
}
var client = new WebClient();
