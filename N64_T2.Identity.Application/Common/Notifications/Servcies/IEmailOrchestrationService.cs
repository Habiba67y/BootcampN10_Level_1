namespace N64_T2.Identity.Application.Common.Notifications.Servcies;

public interface IEmailOrchestrationService
{
    ValueTask<bool> SendAsync(string emailAddress, string message);
}
