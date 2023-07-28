using System.Text.RegularExpressions;
var v = new Validator();
Console.Write("Name: ");
Console.WriteLine(v.isValidname(Console.ReadLine()));
Console.Write("Email address: ");
Console.WriteLine(v.isValidEmailAddress(Console.ReadLine()));
Console.Write("Phone number: ");
Console.WriteLine(v.isValidPhoneNumber(Console.ReadLine()));
public class Validator
{
    private Regex name = new Regex("^[a-zA-Z'-]+$");
    private Regex email = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
    private Regex phone = new Regex("^\\+?\\d{1,3}?[-.\\s]?\\(?\\d{1,4}\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
    public bool isValidname(string n)
    {
        return name.IsMatch(n);
    }
    public bool isValidEmailAddress(string e)
    {
        return email.IsMatch(e);
    }
    public bool isValidPhoneNumber(string p)
    {
        return phone.IsMatch(p);
    }
}