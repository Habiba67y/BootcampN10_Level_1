﻿using N52_HT1.Models;

namespace N52_HT1.Services.Interfaces;

public interface IAccountNotificationService
{
    ValueTask HandleUserCreatedEventAsync(User user);
}
