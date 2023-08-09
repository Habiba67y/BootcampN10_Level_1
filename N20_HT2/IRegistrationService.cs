using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20_HT2
{
    internal interface IRegistrationServive
    {
        void Register(string ism, string familiya, string sharif, string email, string username);
        void Display();
    }
}
