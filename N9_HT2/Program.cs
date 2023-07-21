var events = new Dictionary<string, DateTime>();
events.Add("FrontSpot About new Angular features", new DateTime(2023, 08, 10, 9, 0, 0));
events.Add("AWS Tashkent - Develop your ML Project with Amazon SageMaker", new DateTime(2023, 08, 15, 11, 0, 0));
events.Add("GDG - Google IO Extended", new DateTime(2023, 08, 20, 15, 0, 0));
events.Add("MDC - Sharpist hackathon", new DateTime(2023, 09, 15, 9, 0, 0));
events.Add("WoW 2.0 - Let's talk about Caching", new DateTime(2023, 09, 23, 18, 0, 0));
Console.WriteLine("en");
foreach (var e in events)
{
    if (e.Value.Hour >= 12)
    {
        Console.WriteLine(e.Key+" - " + e.Value.ToString("dd.MM.yyyy hh:mm") + " PM");
    }
    else
    {
        Console.WriteLine(e.Key + " - " + e.Value.ToString("dd.MM.yyyy hh:mm") + " AM");
    }
}
Console.WriteLine("ru");
foreach (var e in events)
{
    Console.WriteLine(e.Key + " - " + e.Value.ToString("dd/MM/yyyy HH:mm"));
}
Console.WriteLine("uz");
foreach (var e in events)
{
    Console.WriteLine(e.Key + " - " + e.Value.ToString("dd.MM.yyyy HH:mm"));
}