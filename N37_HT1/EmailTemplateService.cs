using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_HT1
{
    public class EmailTemplateService
    {
        public IEnumerable<EmailTemplate> GetTemplates(IEnumerable<User> users)
        {
            foreach (var item in users)
            {
                if (item.Status == Status.Registered)
                {
                    yield return new EmailTemplate("registered user", "Hi {{FullName}}, welcome to our system".Replace("{{FullName}}", $"{item.FirstName} {item.LastName}"));
                }
                if (item.Status == Status.Deleted)
                {
                    yield return new EmailTemplate("deleted user", "Dear {{FullName}}, We are sorry to inform you that your account has been deleted from our system. This action was taken because [reason for account deletion]".Replace("{{FullName}}", $"{item.FirstName} {item.LastName}")); 
                }
            }
        }
    }
}
