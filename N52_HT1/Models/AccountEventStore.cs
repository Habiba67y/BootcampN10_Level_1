namespace N52_HT1.Models;

public class AccountEventStore
{
    public event Func<User, ValueTask>? OnUserCreated;
    
    public async ValueTask CreateUserAddedAsync(User user)
    {
        if (user != null)
            await OnUserCreated(user);
    }
}
