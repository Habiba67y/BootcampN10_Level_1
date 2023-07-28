//Buniyam shartiga unchalik ham tushunmadim tushunganimcha:
List<User> userList = new List<User>();
userList.Add(new User("John", "Doe", 30));
userList.Add(new User("Emily", "Smith", 25));
userList.Add(new User("Michael", "Johnson", 35));
userList.Add(new User("Sarah", "Williams", 28));
userList.Add(new User("David", "Brown", 32));
Queue<User> userQueue = new Queue<User>();
foreach (var u in userList)
{
    userQueue.Enqueue(u);
}
var q = true;
for(int i=0; i<userQueue.Count(); i++)
{
    Console.WriteLine(userQueue.ElementAt(i).ToString());
    if (userList[i] != userQueue.ElementAt(i))
    {
        q=false;
    }
}
Console.WriteLine(q);
public class User
{
    public string Ism;
    public string Familiya;
    public int Yosh;
    public User(string ism, string familiya, int yosh)
    {
        Ism = ism;
        Familiya = familiya;
        Yosh = yosh;
    }
    public override string ToString()
    {
        return $"{Ism} {Familiya}, {Yosh}";
    }
}