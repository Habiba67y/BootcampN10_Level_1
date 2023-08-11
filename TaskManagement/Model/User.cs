using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Model
{
    public enum UserRole
    {
        ProjectManager,
        Developer
    }
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public User(string login, string password, int roleId)
        {
            Login = login;
            Password = password;
            Role = roleId;
        }
    }
}
