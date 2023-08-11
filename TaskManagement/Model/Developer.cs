using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Model
{
    public class Developer : User
    {
        public List<Task> AssignedTasks { get; set; }
        public Developer(string username, string password)
            : base(username, password, (int)UserRole.Developer)
        {
            AssignedTasks = new List<Task>();
        }
    }
}
