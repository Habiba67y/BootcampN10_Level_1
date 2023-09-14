using N38_HT1;

var userContainer = new UserContainer();
userContainer.Users.Add(new User("Jonibek", "G'ishmatov", "john@gmail.com"));
userContainer.Users.Add(new User("G'anibek", "Eshmatov", "gani@gmail.com"));
userContainer.Users.Add(new User("Dostonbek", "Toshmatov", "doston@gmail.com"));
userContainer.Users.Add(new User("Farosat", "Jonibekova", "farosatyoq@gmail.com"));
var maleUsers = userContainer.Where(x => x.LastName.EndsWith("v")); //<- LINQ methodlarini foydalanib query qiling degania shunday qildim yana bilmadim
var users = userContainer.Users;
foreach(var user in maleUsers)
    Console.WriteLine(user);
var id = users[0].Id;
Console.WriteLine("\nIndexers\n");
Console.WriteLine(userContainer[id]);
Console.WriteLine(userContainer[1]);
Console.WriteLine(userContainer["sat"]);
