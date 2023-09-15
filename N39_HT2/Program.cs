using N39_HT2;

var accountService = new AccountService();
try
{
    Console.Write("Email: ");
    var email = Console.ReadLine();
    Console.Write("Password: ");
    var password = Console.ReadLine();
    accountService.Register(email, password);
}
catch (ArgumentException a)
{
    Console.WriteLine(a.Message);
}
catch (InvalidOperationException i)
{
    Console.WriteLine(i.Message);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
