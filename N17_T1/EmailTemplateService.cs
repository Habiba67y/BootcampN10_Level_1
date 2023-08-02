using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace N17_T1
{
    internal class EmailTemplateService
    {
        public List<EmailTemplates> Templates= new List<EmailTemplates>();
        public void Add(string subject, string content)
        {
            if (!string.IsNullOrWhiteSpace(subject) && !string.IsNullOrWhiteSpace(content))
            {
                Templates.Add(new EmailTemplates(subject, content));
            }
        }
        public void GetRegistrationTemplate(string username)
        {
            foreach (var t in Templates)
            {
                if (t.Subject == "Account Registration")
                {
                    Console.WriteLine($"Subject: {t.Subject}");
                    Console.WriteLine($"Content: {t.Content.Replace(MessageConstants.UserToken, username)}");
                }
            }
        }
        public void GetAccountBlockedTemplate(string username)
        {
            foreach (var t in Templates)
            {
                if (t.Subject == "Account Blocked")
                {
                    Console.WriteLine($"Subject: {t.Subject}");
                    Console.WriteLine($"Content: {t.Content.Replace(MessageConstants.UserToken, username)}");
                }
            }
        }
    }
}
