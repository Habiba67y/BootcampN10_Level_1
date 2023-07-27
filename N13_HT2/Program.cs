using System.Threading.Channels;
using System.Threading.Tasks.Dataflow;

Console.Write("Harflar: ");
var harf = Console.ReadLine();
Console.Write("Sonlar: ");
var son = Console.ReadLine();
Console.Write("Simvol: ");
var sim = Console.ReadLine();
var sm = false;
var h = false;
var s = false;
if (harf.Equals("ha", StringComparison.OrdinalIgnoreCase))
{
    h = true;
}
if (son.Equals("ha", StringComparison.OrdinalIgnoreCase))
{
    s = true;
}
if (sim.Equals("ha", StringComparison.OrdinalIgnoreCase))
{
    sm = true;
}
Console.Write("uzunlik: ");
var l = int.Parse(Console.ReadLine());
//№1:
var pg = new PasswordGenerate(h, s, l);
Console.WriteLine($"Password: {pg.Generate()}");

//№2:
var spg = new SecurePasswordGenerator(h, s, l, sm);
Console.WriteLine($"Secure Password: {spg.Generate(sm)}");

//№3:
var upg = new UniquePasswordGenerate(h, s, l, sm);
Console.WriteLine($"Unique Password: {upg.GenerateUniquePassword()}");
public class UniquePasswordGenerate : SecurePasswordGenerator
{
    public List<string> passwords = new List<string>();
    public UniquePasswordGenerate(bool hasLetters, bool hasDigits, int length, bool hasSymbols)
        : base(hasLetters, hasDigits, length, hasSymbols)
    { 
    }
    public string GenerateUniquePassword()
    {
        while (true)
        {
            if (!passwords.Contains(Generate(HasSymbol)))
            {
                return Generate(HasSymbol);
            }
        }
    }
}
public class SecurePasswordGenerator : PasswordGenerate
{
    public bool HasSymbol;
    public SecurePasswordGenerator(bool hasLetters, bool hasDigits, int length, bool hasSymbols)
        : base(hasLetters, hasDigits, length)
    {
        HasSymbol = hasSymbols;
    }
    public string Generate(bool hasSymbols)
    {
        Password = "";
        var r = new Random();
        for (int i = 0; i < Length; i++)
        {
            var c = r.Next(1, 4);
            if (c == 1)
            {
                if (HasLetters)
                {
                    if (r.Next(1, 3) == 1)
                    {
                        Password += Convert.ToChar(r.Next(97, 123));
                    }
                    else
                    {
                        Password += Convert.ToChar(r.Next(65, 91));
                    }
                }
                else
                {
                    i--;
                }
            }
            else if (c == 2)
            {
                if (HasDigits)
                {
                    Password += Convert.ToChar(r.Next(48, 58));

                }
                else
                {
                    i--;
                }
            }
            else
            {
                if (HasSymbol)
                {
                    Password += Convert.ToChar(r.Next(33, 48));
                }
                else
                {
                    i--;
                }
            }
        }
        return Password;
    }
}
public class PasswordGenerate
{
    public bool HasLetters;
    public bool HasDigits;
    public int Length;
    public string Password;
    public PasswordGenerate(bool hasLetters, bool hasDigits, int length)
    {
        HasDigits = hasDigits;
        Length = length;
        HasLetters = hasLetters;
    }
    public string Generate()
    {
        var r = new Random();
        for (int i = 0; i < Length; i++)
        {
            var c = r.Next(1, 3);
            if (c == 1)
            {
                if (HasLetters)
                {
                    if (r.Next(1, 3) == 1)
                    {
                        Password += Convert.ToChar(r.Next(97, 123));
                    }
                    else
                    {
                        Password += Convert.ToChar(r.Next(65, 91));
                    }
                }
                else
                {
                    i--;
                }
            }
            else
            {
                if (HasDigits)
                {
                    Password += Convert.ToChar(r.Next(48, 58));

                }
                else
                {
                    i--;
                }
            }
        }
        return Password;
    }

}