using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_HT1
{
    public interface IUserService
    {
        List<User> Get(int pageToken, int pageSize);
        List<User> Search(string searchKeyword, int pageToken, int pageSize);
        List<User> Filter(UserFilterModel userFilterModel);
        User Add(string firstName, string lastName, string emailAddress);
        User Update(User user);
        void Delete(Guid Id);
    }
}
