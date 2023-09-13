using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_HT1
{
    public class UserService
    {
        public List<User> users = new List<User>();
        public IEnumerable<User> GetUsers()
        {
            foreach(var item in users)
                yield return item;
        }
    }
}
