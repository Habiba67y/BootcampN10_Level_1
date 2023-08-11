using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Model;

namespace TaskManagement.Interfaces
{
    public interface IUser
    {
        void AddUser(User user);
        int AuthenticateUser(string login, string password, User user);
    }
}
