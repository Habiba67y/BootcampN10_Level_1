using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N38_HT1
{
    public class UserContainer: IEnumerable<User>
    {
        public List<User> Users;
        public UserContainer() 
        {
            Users = new List<User>();
        }
        public UserContainer(List<User> users)
        {
            Users = users;
        }

        public IEnumerator<User> GetEnumerator()
        {
            return Users.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public User this[Guid id] => Users.First(x => x.Id == id);
        public User this[string keyword] => Users.First(x => x.FirstName.Contains(keyword) || x.LastName.Contains(keyword) || x.EmailAddress.Contains(keyword));
        public User this[int index] => Users[index];
    }
}
