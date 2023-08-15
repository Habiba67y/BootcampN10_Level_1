using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace N24_HT1
{
    public class UserCredentialService: IUserCredentialService
    {
        private readonly IUserService _userService;
        public List<UserCredentials> userCredentials = new List<UserCredentials>();
        public UserCredentials Add(Guid userId, string password)
        {
            var passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");
            if (passwordRegex.IsMatch(password))
            {
                var userCredential = new UserCredentials(password, userId);
                userCredentials.Add(userCredential);
                return userCredential;
            }
            else
            {
                throw new Exception("Invalid password");
            }
        }
        public UserCredentials GetByUserId(Guid userId)
        {
            return userCredentials.FirstOrDefault(uc => uc.UserId == userId);
        }
        public UserCredentialService(IUserService userService)
        {
            _userService = userService;
        }
    }
}
