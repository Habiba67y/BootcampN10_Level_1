using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace N27_HT1
{
    public class UserService
    {
        public List<User> Users { get; set; }
        public void Add(string email, string password)
        {
            var emailRegex = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            var passwordRegex = new Regex("^(.{8,}|[^0-9]*|[^A-Z])$");
            if (emailRegex.IsMatch(email) && passwordRegex.IsMatch(password))
            {
                Users.Add(new User(email, password, false));
            }
            
        }
        public void GetUsers()
        {
            Users.ForEach(Console.WriteLine);
        }
        private bool EnsureAdminExists()
        {
            var exists = false;
            var admin = Users.FirstOrDefault(admin => admin.IsAdmin);
            if(admin != null)
                exists = true;
            return exists;
        }
        public UserService() 
        {
            Users = new List<User>
            {
                new User("falonchi@gmail.com", "fAlon5chi", true),
                new User("palonchi@gmail.com", "pAlo4nchi", true),
                new User("pistonchi@gmail.com", "pisTon1chi", false)
            };
            EnsureAdminExists();
        }
    }
}
