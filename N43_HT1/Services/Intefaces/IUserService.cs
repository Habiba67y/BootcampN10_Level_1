using N43_HT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N43_HT1.Services.Intefaces
{
    public interface IUserService
    {
        Guid Create(string firstName, string lastName);
        User GetById(Guid id);
        List<User> Get();
        User? Update(User user);
        bool Delete(Guid id);
    }
}
