using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_HT1
{
    public class RegistrationService
    {
        private readonly IUserService _userService;
        private readonly IUserCredentialService _userCredentialService;
        public bool Register(string firstName, string lastName, string emailAddress, string password)
        {
            _userCredentialService.Add(_userService.Add(firstName, lastName, emailAddress).Id, password);
            return true;
        }
        public RegistrationService(IUserService us, IUserCredentialService ucs)
        {
            _userService = us;
            _userCredentialService = ucs;
        }
    }
}
