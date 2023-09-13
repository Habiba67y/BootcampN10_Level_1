using N37_HT1;

var userService = new UserService();
var emailTemplateService = new EmailTemplateService();
var emailService = new EmailService();
var emailSenderService = new EmailSenderService();
var notificationManagementService = new NotificationManagementService(userService, emailTemplateService, emailSenderService, emailService);
userService.users.Add(new User("G'ishmat", "G'ishmatov", "giwmat@gmail.com", Status.Registered));
userService.users.Add(new User("Eshmat", "Eshmatov", "ewmat@gmail.com", Status.Deleted));
userService.users.Add(new User("Toshmat", "Toshmatov", "towmat@gmail.com", Status.Registered));
userService.users.Add(new User("Aziz", "Abdurahmonov", "abdura52.uz@gmail.com", Status.Registered));
await notificationManagementService.NotifyUsers();