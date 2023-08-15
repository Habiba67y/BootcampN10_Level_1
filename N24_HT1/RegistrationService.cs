using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_HT1
{
    public class RegistrationService
    {
        public bool Register(string firstName, string lastName, string emailAddress, string password)
        {
            var userService = new UserService();
            var userCredentialService = new UserCredentialService(userService);
            userCredentialService.Add(userService.Add(firstName, lastName, emailAddress).Id, password);
            return true;
        }
    }
}
