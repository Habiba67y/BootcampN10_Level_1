//№1:0
//var wr = new WeatherReport();
//wr.Add(new DateOnly(2023, 07, 30), 38);
//wr.Add(new DateOnly(2023, 07, 29), 37);
//wr.Add(new DateOnly(2023, 07, 28), 36);
//wr.Add(new DateOnly(2023, 07, 27), 35);
//wr.Add(new DateOnly(2023, 07, 26), 36);
//wr.Add(new DateOnly(2023, 07, 25), 37);
//Console.Write("Kun kiriting: ");
//var kun1 = int.Parse(Console.ReadLine());
//Console.WriteLine(wr.Get(new DateOnly(2023, 07, kun1)));
//var kun2 = int.Parse(Console.ReadLine());
//Console.WriteLine(wr.Get(new DateOnly(2023, 07, kun2)));

//№2:
//var vwr = new ValidatedWeatherReport();
//vwr.Add(new DateOnly(2023, 07, 30), 38);
//vwr.Add(new DateOnly(2023, 07, 29), 37);
//vwr.Add(new DateOnly(2023, 07, 28), 36);
//vwr.Add(new DateOnly(2023, 07, 27), 35);
//vwr.Add(new DateOnly(2023, 07, 26), 36);
//vwr.Add(new DateOnly(2023, 07, 30), 37);
//foreach (var w in vwr.weathers)
//{
//    Console.WriteLine($"Sana: {w.Key}\nOb-havo: {w.Value}");
//}

//№3:
//ochig'i 3-shartga uncha tushunmadim tushunganimcha qildim:
using System.Collections.Generic;

var uwr = new UltimateWeatherReport();
uwr.Add(new DateOnly(2023, 07, 29), 38);
uwr.Add(new DateOnly(2023, 07, 31), 37);
uwr.Add(new DateOnly(2023, 08, 2), 36);
uwr.Add(new DateOnly(2023, 08, 3), 35);
uwr.Add(new DateOnly(2023, 08, 4), 36);
uwr.Add(new DateOnly(2023, 08, 6), 37);
uwr.Add(new DateOnly(2023, 08, 5), 36);
uwr.Add(new DateOnly(2023, 08, 3), 35);
uwr.Add(new DateOnly(2023, 08, 1), 36);
uwr.Add(new DateOnly(2023, 07, 30), 37);
Console.WriteLine("\nGet methodiga 11 kun berganimda:");
if (uwr.Get(11) != default(List<DateOnly>))
{
    foreach (var w in uwr.Get(11))
    {
        Console.WriteLine($"Sana: {w}Ob-havo: {uwr.weathers[w]}");
    }
}

Console.WriteLine("\nGet methodiga 3 kun berganimda:");
if (uwr.Get(3) != default(List<DateOnly>))
{ 
    foreach (var w in uwr.Get(3))
    {
        Console.WriteLine($"Sana: {w} Ob-havo:  {uwr.weathers[w]}");
    }
}
Console.WriteLine("\nGet() methodini o'zi: ");
foreach (var w in uwr.Get())
{
    Console.WriteLine($"Sana: {w}  Ob-havo:   {uwr.weathers[w]}");
}
public class WeatherReport
{
    public Dictionary<DateOnly, int> weathers = new Dictionary<DateOnly, int>();
    public virtual void Add(DateOnly sana, int obHave)
    {
        weathers.Add(sana, obHave);
    }
    private string Find(DateOnly sana)
    {
        foreach (var weather in weathers)
        {
            if (sana.Year == weather.Key.Year && sana.Month == weather.Key.Month && sana.Day == weather.Key.Day)
            {
                return $"Sana: {weather.Key.ToString("dd/MM/yyyy")}\nOb-havo: {weather.Value} gradus";
            }
        }
        return null;
    }
    public string Get(DateOnly sana) 
    {
        if (Find(sana) != null)
        {
            return Find(sana);
        }
        return "Berilgan kunga ob-havo topilmadi";
    }
}
public class ValidatedWeatherReport : WeatherReport
{
    public override void Add(DateOnly sana, int obHave)
    {
        if (weathers.ContainsKey(sana))
        {
            weathers[sana] = obHave;
        }
        else
        {
            weathers.Add(sana, obHave);
        }
    }
}
public class UltimateWeatherReport : ValidatedWeatherReport
{
    private List<DateOnly> Sort()
    {
        var sana = weathers.Keys.ToList();
        for (int i = 0; i < sana.Count - 1; i++)
        {
            for (int j = i + 2; j < sana.Count; j++)
            {
                if (sana[i].DayOfYear > sana[j].DayOfYear)
                {
                    var temp = sana[i];
                    sana[i] = sana[j];
                    sana[j]=temp;
                }
            }
        }
        return sana; 
    }
    public List<DateOnly> Get()
    {
        return Sort();
    }
    public List<DateOnly>Get(int kun)
    {
        var now = DateTime.Now;
        if (Sort()[Sort().Count-1].DayOfYear < now.DayOfYear + kun)
        {
            Console.WriteLine("Uzr, to'liq ma'lumot yo'q");
            return default(List<DateOnly>);
        }
        var get = new List<DateOnly>();
        foreach (var s in Sort())
        {
            if (s.DayOfYear > now.DayOfYear + kun)
            {
                break;
            }
            get.Add(s);
        }
        return get; 
    }
}