//Bogus library dan foydalaning quyidagi modellarga fake data generate qiling va ekranga chiqaring
using Bogus;
using N38_HT2;
using System.Text.Json;

var employee = new Faker<Employee>()
    .RuleFor(e => e.Id, Guid.NewGuid())
    .RuleFor(e => e.FirstName, f => f.Person.FirstName)
    .RuleFor(e => e.LastName, f => f.Person.LastName)
    .RuleFor(e => e.EmailAddress, f => f.Person.Email)
    .RuleFor(e => e.Salary, f => f.Random.Decimal(1000, 5000));
Console.WriteLine(JsonSerializer.Serialize(employee.Generate()));
Console.WriteLine();
var order = new Faker<Order>()
    .RuleFor(o => o.Id, Guid.NewGuid())
    .RuleFor(o => o.Name, f => f.Lorem.Word())
    .RuleFor(o => o.OrderDate, DateTime.Now.AddDays(-30))
    .RuleFor(o => o.Amount, f => f.Random.Number(1, 15));
Console.WriteLine(JsonSerializer.Serialize(order.Generate()));
Console.WriteLine();
var userAddress = new Faker<UserAddress>()
    .RuleFor(u => u.UserId, employee.Generate().Id)
    .RuleFor(u => u.TownName, f => f.Address.Country())
    .RuleFor(u => u.RoadName, f => f.Address.StreetName())
    .RuleFor(u => u.HouseNumber, f => f.Address.BuildingNumber());
Console.WriteLine(JsonSerializer.Serialize(userAddress.Generate()));
Console.WriteLine();
var blogPost = new Faker<BlogPost>()
    .RuleFor(b => b.Id, Guid.NewGuid())
    .RuleFor(b => b.OwnerId, employee.Generate().Id)
    .RuleFor(b => b.Title, f => f.Lorem.Word())
    .RuleFor(b => b.Body, f => f.Lorem.Text())
    .RuleFor(b => b.PostedTime, DateTime.Now.AddDays(-25));
Console.WriteLine(JsonSerializer.Serialize(blogPost.Generate()));
Console.WriteLine();
var weatherReport = new Faker<WeatherReport>()
    .RuleFor(w => w.Temperature, f => f.Random.Number(-10, 50))
    .RuleFor(w => w.Humidity, f => f.Random.Number(1, 101))
    .RuleFor(w => w.WindSpeed, f => f.Random.Float(1, 100))
    .RuleFor(w => w.ReportTime, DateTime.Now);
Console.WriteLine(JsonSerializer.Serialize(weatherReport.Generate()));
Console.WriteLine();