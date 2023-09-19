using N41_HT2.Service.Services;

var emailSenderservice = new EmailSenderService();
var tasks = new List<Task>()
{
    new(() => emailSenderservice.SendEmailAsync("sattorovahabiba00@gmail.com")),
    new (() => emailSenderservice.SendEmailAsync("falonchi@gmail.com")),
    new(() => emailSenderservice.SendEmailAsync("jonibek@gmail.com"))
};
Parallel.ForEach(tasks, task => task.Start());
await Task.WhenAll(tasks);