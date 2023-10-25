using Mapster;
using UsingMapster.DTOs;
using UsingMapster.Entities;

namespace UsingMapster.Service;

public class UserService
{
    private IList<User> _users = new List<User>();
    public User Create(UserForCreation user)
    {
        var exisrUser = _users.FirstOrDefault(u => u.EmailAddress.Equals(user.EmailAddress));
        if (exisrUser != null) 
        {
            Console.WriteLine("Bu email address ga akkount ochilgan");
            return exisrUser;
        }
        var newUser = user.Adapt<User>();

        newUser.Id = Guid.NewGuid();
        newUser.CreatedAt = DateTime.Now;
        newUser.UpdatedAt = DateTime.Now;

        _users.Add(newUser);

        return newUser; 
    }
    public List<UserViewModel> Users()
        => _users.Adapt<List<UserViewModel>>();


}
