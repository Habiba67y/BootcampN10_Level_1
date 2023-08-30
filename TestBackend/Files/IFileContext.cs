using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBackend.Models;

namespace TestBackend.Files
{
    public interface IFileContext
    {
        User AddUser(User user);
        List<User> GetUsers();
        User? GetById(Guid Id);
        User Update(User user);
        User Delete(User user);
    }
}
