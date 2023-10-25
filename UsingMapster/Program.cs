using Sharprompt;
using UsingMapster.DTOs;
using UsingMapster.Service;

var service = new UserService();
while (true)
{
    var choose = Prompt.Select("Tanlang", new[] { "User yaratish", "Userlar"});
    if (choose == "User yaratish")
    {
        var firstName = Prompt.Input<string>("Ism kiriting");
        var lastName = Prompt.Input<string>("Familiya kiriting");
        var email = Prompt.Input<string>("Email kiriting");
        var password = Prompt.Input<string>("Password kiriting");
        var userName = Prompt.Input<string>("Username kiriting");

        var user = new UserForCreation()
        {
            FirstName = firstName,
            LastName = lastName,
            EmailAddress = email,
            Password = password,
            UserName = userName,
        };

        service.Create(user);
    }
    else if (choose == "Userlar")
    {
        var users = service.Users();
        foreach (var user in users)
        {
            Console.WriteLine($"{user.LastName} {user.FirstName} {user.UserName} {user.CreatedAt}");
            Prompt.Input<string>(" ");
        }
    }

    Console.Clear();
}