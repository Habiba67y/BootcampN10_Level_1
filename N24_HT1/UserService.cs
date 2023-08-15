using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_HT1
{
    public class UserService: IUserService
    {
        private List<User> users = new List<User>();
        public List<User> Get(int pageToken, int pageSize)
        {
            return users.Skip((pageToken-1)*pageSize).Take(pageSize).ToList();
        }
        public List<User> Search(string searchKeyword, int pageToken, int pageSize)
        {
            var us = users.Where(user => 
            user.FirstName.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase) 
            || user.LastName.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase)
            || user.EmailAddress.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase)).ToList();
            return us.Skip((pageToken - 1) *pageSize).Take(pageSize).ToList();
        }
        public List<User> Filter(UserFilterModel userFilterModel)
        {
            var us = users.Where(user =>
            (userFilterModel.FirstName is null || user.FirstName.Equals(userFilterModel.FirstName, StringComparison.OrdinalIgnoreCase)
            && (userFilterModel.LastName is null || user.LastName.Equals(userFilterModel.LastName, StringComparison.OrdinalIgnoreCase)))).ToList();
            return us.Skip((userFilterModel.PageToken-1)*userFilterModel.PageSize).Take(userFilterModel.PageSize).ToList();
        }
        public User Add(string firstname, string lastName, string emailAddress)
        {
            if (users.FirstOrDefault(user => user.EmailAddress.Equals(emailAddress)) is null)
            {
                var user = new User(firstname, lastName, emailAddress, false);
                users.Add(user);
                return user;
            }
            else
            {
                throw new Exception("Bu email address dan user ochilib bo'lgan");
            }
        }
        public User Update(User user)
        {
            if (users.Contains(user))
            {
                Console.Write("Firstname: ");
                user.FirstName = Console.ReadLine();
                Console.Write("Lastname: ");
                user.LastName = Console.ReadLine();
                Console.Write("Email address: ");
                user.EmailAddress = Console.ReadLine();
                return user;
            }
            else
            {
                throw new Exception("Bunday user mavjud emas");
            }
        }
        public void Delete(Guid Id)
        {
            var user = users.FirstOrDefault(user => user.Id == Id);
            if (user != null)
            {
                user.isDeleted = true;
            }
            else
            {
                throw new Exception("Bunday user mavjud emas");
            }
        }

    }
}
