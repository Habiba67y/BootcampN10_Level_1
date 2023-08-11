using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Model
{
    public class ProjectManager: User
    {
        public ProjectManager(string username, string password)
            :base(username, password, (int)UserRole.ProjectManager)
        {
        }
    }
}
