using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N41_HT2.Service.Interfaces
{
    public interface IEmailSenderService
    {
        public ValueTask<bool> SendEmailAsync(string email);
    }
}
