using N33_HT1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N33_HT1.Objects
{
    partial class UsersManagement
    {
        private readonly List<User> UserList = new()
        {
            new User("John", "Doe", false),
            new User("Jonibek", "Doniyorov", false),
            new User("Jane", "Doe", true),
            new User("Tommy", "Hilfiger", false),
            new User("Mark", "Polo", true),
        };

        public IEnumerable<User> GetByCreatedDate(bool includeAdmin)
        {
            return UserList.Where(user => includeAdmin || user.Admin == false).OrderByDescending(user => user.CreatedDate);
        }

        //public List<UserModel> GetByCreatedDate(bool includeAdmin)
        //{
        //    return UserList.Where(user => includeAdmin || user.Admin == false).OrderByDescending(user => user.Created).ToList();
        //}
    }
}
