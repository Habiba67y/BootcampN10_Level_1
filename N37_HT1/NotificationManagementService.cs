using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_HT1
{
    public class NotificationManagementService
    {
        private UserService _userService;
        private EmailTemplateService _emailTemplateService;
        private EmailSenderService _emailSenderService;
        private EmailService _emailService;
        public NotificationManagementService(UserService userService, EmailTemplateService emailTemplateService, EmailSenderService emailSenderService, EmailService emailService)
        {
            _userService = userService;
            _emailTemplateService = emailTemplateService;
            _emailSenderService = emailSenderService;
            _emailService = emailService;
        }
        public async Task NotifyUsers()
        {
            var users = _userService.GetUsers();
            var templates = _emailTemplateService.GetTemplates(users);
            var messages = _emailService.GetMessages(templates, users);

            await _emailSenderService.SendEmailsAsync(messages);
        }
    }
}
