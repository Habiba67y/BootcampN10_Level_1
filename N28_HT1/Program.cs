using N28_HT1.DataAccess;
using N28_HT1.Models.Entities;

var eventStack = new EventStack<Event>();
eventStack.Push(new Event("yaxshi event", DateTime.Now.AddHours(2)));
eventStack.Push(new Event("ajoyib event", DateTime.Now.AddHours(5)));
eventStack.Push(new Event("kutilmagan event", DateTime.Now.AddHours(6)));
//var eventA = eventStack.Peek();
//eventA.Date = DateTime.Now;
//eventStack.Push(eventA); <= shartga ko'ra exception beradi

for (var i = 0; i<eventStack.Length()+2; i++)
    Console.WriteLine(eventStack.Pop());


