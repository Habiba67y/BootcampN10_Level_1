using N34;
using System.Text.Json;

var service = new History();
service.Add(new Person(1, "Falonchi", "falonchiyev"));
service.Add(new Person(2, "Palonchi", "Palonchiyev"));
service.Update(new Person(1, "Pistonchi", "Familiya"));
service.Remove(service.people[0]);
service.Display();