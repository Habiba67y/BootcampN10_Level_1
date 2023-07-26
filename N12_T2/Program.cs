var u1 = new User()
{
    FirstName = "Peter",
    LastName = "Michael",
    sharif = "Brown"
};
var u2 = new User()
{
    FirstName = "John",
    LastName = "David",
    sharif = "Smith"
};
var u3 = new User()
{
    FirstName = "Mary",
    LastName = "Anne",
    sharif = "Jones"
};
var u4 = new User()
{
    FirstName = "G`ishtmat",
    LastName = "G`ishtmatov",
    sharif = "G`ishtmatovich"
};
Queue<User> users = new Queue<User>();
users.Enqueue(u1);
users.Enqueue(u2);
users.Enqueue(u3);
users.Enqueue(u4);
Console.Write("Ism: ");
var ism = Console.ReadLine();
Console.Write("Familiya: ");
var fam = Console.ReadLine();
Console.Write("sharif: ");
var sh = Console.ReadLine();
var u = new User()
{
    FirstName = ism,
    LastName = fam,
    sharif = sh
};
var m = false;
foreach (var user in users)
{
    if (user.Equals(u))
    {
        Console.WriteLine($"{u.LastName} {u.FirstName}, siz navbatda ekansiz allaqachon");
        m = true;
    }
}
if (m == false)
{
    users.Enqueue(u);
    Console.WriteLine("Navbatga qo'shildiz");
}
public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string sharif { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj is User user)
            return this.GetHashCode() == user.GetHashCode();
        return false;
    }

    public override int GetHashCode()
    {
        return FirstName.GetHashCode()
            + LastName.GetHashCode()
            + sharif.GetHashCode();
    }
}