using N19_HT1;

Console.Write("Enter your name: ");
var name = Validator.IsValidName(Console.ReadLine(), out var fn);
if (name)
{
    Console.WriteLine(fn);
}
Console.WriteLine(name);
Console.Write("Enter your email address: ");
var emailAddress = Validator.IsValidEmailAddress(Console.ReadLine(), out var fe);
if (emailAddress)
{
    Console.WriteLine(fe);
}
Console.WriteLine(emailAddress);
Console.Write("Enter your age: ");
var age = Validator.IsValidAge(Console.ReadLine());
Console.WriteLine(age);
Console.Write("Enter your phone number: ");
var phoneNumber = Validator.IsValidPhone(Console.ReadLine(), out var fp);
if(phoneNumber)
{ 
    Console.WriteLine(fp);
}
Console.WriteLine(phoneNumber);