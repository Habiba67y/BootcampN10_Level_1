using System.ComponentModel;
var em = new EventManager();
em.Add("Ertangi kun", new DateTime(2023, 07, 27, 12, 00, 00));
em.Add("Bugun peshin vaqti", new TimeOnly(13, 00, 00));
em.Add("Indingi kun", new DateTime(2023, 07, 28, 15, 30, 00));
em.Add("Bugun asr vaqti", new TimeOnly(18, 00, 00));
em.Add("Indinni ertasi kuni", new DateTime(2023, 07, 29, 14, 00, 00));
em.Add("Bugun shom vaqti", new TimeOnly(20, 10, 00));
em.Display();
public class EventManager
{
    public Dictionary<string, DateTime> nd = new Dictionary<string, DateTime>();
    public Dictionary<string, TimeOnly> nt = new Dictionary<string, TimeOnly>();
    public void Add(string name, DateTime dateTime)
    {
        nd.Add(name, dateTime);
    }
    public void Add(string name, TimeOnly timeOnly)
    {
        nt.Add(name, timeOnly);    
    }
    public void Display()
    {
        foreach (var ev in nt)
        {
            Console.WriteLine($"Name: {ev.Key}\nTime: {ev.Value}");
        }
        foreach (var ev in nd)
        {
            Console.WriteLine($"Name: {ev.Key}\nTime: {ev.Value}");
        }
    }
}