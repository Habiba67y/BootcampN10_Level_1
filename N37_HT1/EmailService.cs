using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_HT1
{
     public class EmailService
    {
        public IEnumerable<EmailMessage> GetMessages(IEnumerable<EmailTemplate> templates, IEnumerable<User> users)
        {
            foreach (var item in templates.Zip(users))
            {
                yield return new EmailMessage(item.First.Subject, item.First.Body, "sultonbek.rakhimov@gmail.com", item.Second.EmailAddress);
            }
        }
    }
}
