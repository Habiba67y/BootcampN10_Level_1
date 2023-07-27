Console.Write("Ism: ");
var ism = Console.ReadLine();
Console.Write("Familiya: ");
var fam = Console.ReadLine();
Console.Write("Deposit: ");
var dep = int.Parse(Console.ReadLine());
var b1 = new BankAccount(ism, fam);
var b2 = new BankAccount(ism, fam, dep);
Console.WriteLine($"Bank 1-akount:\n{b1.FirstName} {b1.LastName}");
Console.WriteLine($"Bank 2-akount:\n{b2.FirstName} {b2.LastName} {b2.Deposit}");
Console.Write("Passport: ");
var pas = Console.ReadLine();
var s1 = new SecureBankAccount(ism, fam, dep);
var s2 = new SecureBankAccount(ism, fam, pas, dep);
Console.WriteLine($"Secure bank 1-akount:\n{s1.FirstName} {s1.LastName} {s1.Deposit}");
Console.WriteLine($"Secure bank 2-akount:\n{s2.FirstName} {s2.LastName} {s2.Deposit} {s2.Passport}");
public class BankAccount
{
    public string FirstName;
    public string LastName;
    public int Deposit;
    public BankAccount(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public BankAccount(string firstName, string lastName, int deposit=20)
        :this(firstName, lastName)
    {
        if (deposit > 0)
        {
            Deposit = deposit;
        }
        else
        {
            Console.WriteLine("Deposit 0 dan katta kiritish kerak");
        }
    }
}
public class SecureBankAccount : BankAccount
{
    public string Passport;
    public int Deposit;
    public SecureBankAccount(string firstName, string lastName, int deposit)
        : base(firstName, lastName)
    {
        Deposit = deposit;
    }
    public SecureBankAccount(string firstName, string lastName, string passport, int deposit)
        :base(firstName, lastName, deposit)
    {
        Deposit = deposit;
        Passport = passport;
    }
}