using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N21
{
    internal class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public List<Project> AssignedProjects = new List<Project>();
        public List <string> Comments = new List<string>();
        public User(string username, string password, int roleId, string email)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            RoleId = roleId;
            Email = email;
        }
    }
}
