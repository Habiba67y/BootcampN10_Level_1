using N40_T1.Service;

var accountService = new AccountService();
try
{
    accountService.Register("Habiba", "Sattorova", "sattorovahabibagmail.com", "sdfghj3456");
}
catch (InvalidDataException i)
{
    Console.WriteLine(i.Message);
}
catch (ArgumentException a)
{
    Console.WriteLine(a.Message);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}