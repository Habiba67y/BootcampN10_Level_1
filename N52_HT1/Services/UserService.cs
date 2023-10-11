using N52_HT1.Models;
using N52_HT1.Services.Interfaces;

namespace N52_HT1.Services;

public class UserService : IUserService
{
    private readonly AccountEventStore _eventStore;
    public UserService(AccountEventStore accountEventStore)
    {
        _eventStore = accountEventStore;
    }

    public async ValueTask<User> Create(User user)
    {
        await _eventStore.CreateUserAddedAsync(user);

        return user;
    }
}
