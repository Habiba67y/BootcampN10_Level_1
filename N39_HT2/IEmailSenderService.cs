using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N39_HT2
{
    public interface IEmailSenderService
    {
        bool SendEmail(string emailAddress);
    }
}
