Console.WriteLine("Password yaratamiz:");
Console.Write("Harflar bo'lsinmi: ");
var h = Console.ReadLine();
var harflar = false;
Console.Write("Sonlar bo'lsinmi: ");
var sn = Console.ReadLine();
var sonlar = false;
Console.Write("Simvol bo'lsinmi: ");
var sm = Console.ReadLine();
var simvollar = false;
if (h == "ha")
{
    harflar = true;
}
if (sn == "ha")
{
    sonlar = true;
}
if (sm == "ha")
{
    simvollar = true;
}
Console.Write("Password uzunligi: ");
var l =Convert.ToInt32(Console.ReadLine());
var passwordGenerator = new PasswordGenerator();
Console.WriteLine(passwordGenerator.Generate(sonlar, harflar, simvollar, l));
public class PasswordGenerator
{
    public string Generate(bool hasDigits, bool hasLetters, bool hasSymbols, int length)
    {
        string password = "";
        var r = new Random();
        for (int i = 0; i < length; i++)
        {

            var c = r.Next(1, 4);
            if (c == 1)
            {
                if (hasLetters)
                {
                    Console.Write("Katta harflar - 1\nKichik harflar - 2\n->");
                    var k = Convert.ToInt32(Console.ReadLine());
                    if (k == 1)
                    {
                        password += Convert.ToChar(r.Next(65, 91));
                    }
                    if (k == 2)
                    {
                        password += Convert.ToChar(r.Next(97, 123));
                    }
                }
                else
                {
                    i--;
                }
            }
            if (c == 2)
            {
                if (hasDigits)
                {
                    password += Convert.ToChar(r.Next(48, 58));
                }
                else 
                {
                    i--;
                }
            }
            if (c == 3)
            {
                if (hasSymbols)
                {
                    password += Convert.ToChar(r.Next(33, 48));
                }
                else
                {
                    i--;
                }
            }
        }
        return password;

    }
}
