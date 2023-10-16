using N53_HT1.Api.Services.Interfaces;

namespace N53_HT1.Api.Services;

public class EmailSenderService : INotificationService
{
    public ValueTask SendAsync(Guid userId, string content)
    {
        Console.WriteLine($"Sending email to {userId} with content: {content}");

        return new ValueTask();
    }
}
