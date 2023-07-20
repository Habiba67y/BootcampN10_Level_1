var odamlarIsmi = new LinkedList<string>();
odamlarIsmi.AddLast("Parizoda");
odamlarIsmi.AddLast("Marjona");
odamlarIsmi.AddLast("Sevinch");
odamlarIsmi.AddLast("Xadicha");
var samalyotUchishlari = new Dictionary<DateTime, int>();
samalyotUchishlari.Add(new DateTime(2023, 7, 17, 9, 0, 0), 4);
samalyotUchishlari.Add(new DateTime(2023, 7, 19, 16, 0, 0), 6);
samalyotUchishlari.Add(new DateTime(2023, 7, 18, 12, 30, 0), 3);
string name;
var CompanyName = "The Travel Guru";
var NameToken = "{{Name}}";
var CompanyNameToken = "{{CompanyName}}";
var TicketdateToken = "{{TicketDate}}";
var underAge = "Uzr, hurmatli {{Name}} siz loyihadan foydalanish uchun kichkinasiz";
var goldenAger = "Uzr, hurmatli {{Name}} loyiha yoshlar uchun mo'ljallangan";
var emails = new LinkedList<string>();
emails.AddLast("Hello {{Name}}. Welcome to onboard. {{CompanyName}} Team.");
emails.AddLast("Your data is being processed and we will inform updates for you as soon as possible. {{CompanyName}} Team");
emails.AddLast("Congratulations! Your flight ticket is booked for {{TicketDate}}. {{CompanyName}} Team.");
while (true)
{
    Console.Write("Enter your name: ");
    name = Console.ReadLine();
    if ((name).Any(char.IsDigit))
    {
        Console.WriteLine("Invalid name");
    }
    else
    {
        Console.WriteLine("Good!");
        break;
    }
}
Console.Write("Enter your age: ");
var age = Console.ReadLine();
if (Convert.ToInt32(age) < 18)
{
    Console.WriteLine(underAge.Replace(NameToken, name));
}
else if (Convert.ToInt32(age) > 90)
{
    Console.WriteLine(goldenAger.Replace(NameToken, name));
}
else
{
    var e = emails.ElementAt(0)
        .Replace(NameToken, name)
        .Replace(CompanyNameToken, CompanyName);
    Console.WriteLine(e);
    odamlarIsmi.AddLast(name);
    e = emails.ElementAt(1)
        .Replace(CompanyNameToken, CompanyName);
    Console.WriteLine(e);
    foreach (var flight in samalyotUchishlari)
    {
        if (flight.Value >= odamlarIsmi.Count)
        {
            e = emails.ElementAt(2)
                .Replace(TicketdateToken, Convert.ToString(flight.Key))
                .Replace(CompanyNameToken, CompanyName);
            Console.WriteLine(e);
            break;
        }
    }
}