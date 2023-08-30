using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBackend.Files;
using TestBackend.Models;

namespace TestBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IFileContext _fileContext;
        public UserService(IFileContext fileContext)
        {
            _fileContext = fileContext;
        }
        public User AddUser(User user)
        {
            return _fileContext.AddUser(user);
        }

        public User Delete(User user)
        {
            return _fileContext.Delete(user);
        }

        public User? GetById(Guid Id)
        {
            return _fileContext.GetById(Id);
        }

        public List<User> GetUsers()
        {
            return _fileContext.GetUsers();
        }

        public User Update(User user)
        {
            return _fileContext.Update(user);
        }
    }
}
