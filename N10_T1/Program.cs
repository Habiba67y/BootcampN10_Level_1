Console.Write("Your first name: ");
var fn = Console.ReadLine();
Console.Write("Your last name: ");
var ln = Console.ReadLine();
Console.Write("Your age: ");
var a = Convert.ToInt32(Console.ReadLine());
User user = new User()
{
    FirstName = fn,
    LastName = ln,
    age = a,
};
Console.WriteLine($"First Name: {user.FirstName}\nLast Name: {user.LastName}\nAge: {user.age}");
public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int age { get; set; }
}