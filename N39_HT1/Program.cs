using N39_HT1;

var weatherReport1 = new WeatherReport("Hot", 35);
var weatherReport2 = new WeatherReport("Warm", 25);
var weatherReport3 = new WeatherReport("Cold", 20);
var user1 = new User("Pearl", "Huel");
var user2 = new User("John", "Doe");
var user3 = new User("Grant", "Torp");
var list = new List<object>()
{
    weatherReport1,
    weatherReport2,
    weatherReport3,
    user1,
    user2,
    user3
};
foreach (var item in list)
{
    if (item is User { FirstName: "John" })
        Console.WriteLine(item);
    if (item is WeatherReport { Degree: >= 30 })
        Console.WriteLine(item);
}