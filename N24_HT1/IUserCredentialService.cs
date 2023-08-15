using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N24_HT1
{
    public interface IUserCredentialService
    {
        UserCredentials Add(Guid userId, string password);
        UserCredentials GetByUserId(Guid userId);
    }
}
