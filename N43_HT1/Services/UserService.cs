using N43_HT1.Models;
using N43_HT1.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N43_HT1.Services
{
    public class UserService: IUserService
    {
        public List<User> _users = new List<User>();
        public Guid Create(string firstName, string lastName)
        {
            var user = new User(firstName, lastName);
            _users.Add(user);
            return user.Id;
        }
        public User GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
        public List<User> Get()
        {
            return _users;
        }
        public User? Update(User user)
        {
            var updateUser = _users.FirstOrDefault(x => x.Id == user.Id);
            if (updateUser != null)
            {
                updateUser.FirstName = user.FirstName;
                updateUser.LastName = user.LastName;
            }
            return updateUser;
        }
        public bool Delete(Guid id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            user.IsActive = false;
            return !user.IsActive;
        }
    }
}
