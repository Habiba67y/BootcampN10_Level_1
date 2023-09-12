using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N36_HT2
{
    public class UserService
    {
        public List<User> users;
        public UserService()
        {
            users = new List<User>();
        }
        public Guid Create(string firstName, string lastName)
        {
            var user = new User(firstName, lastName);
            users.Add(user);
            return user.Id;
        }
        public void Read()
        {
            users.ForEach(Console.WriteLine);
        }
        public User? Update(User user)
        {
            var foundUser = users.FirstOrDefault(x => x.Id == user.Id);
            if (foundUser != null)
            {
                foundUser.FirstName = user.FirstName;
                foundUser.LastName = user.LastName;
            }
            return foundUser;
        }
        public User? Delete(Guid id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user != null)
                users.Remove(user);
            return user;
        }
    }
}
