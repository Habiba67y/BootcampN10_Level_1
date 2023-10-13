using N53_HT1.Api.Events;
using N53_HT1.Api.Services;
using N53_HT1.Api.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;
using FileBaseContext.Context.Models.Configurations;
using N53_HT1.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDataContext, AppFileContext>(provider =>
{
    var options = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "Storage")
    };
    var dataContext = new AppFileContext(options);
    dataContext.FetchAsync().AsTask().Wait();

    return dataContext;
});

builder
    .Services
    .AddSingleton<IUserService, UserService>()
    .AddSingleton<IOrderService, OrderService>()
    .AddSingleton<IBonusService, BonusService>()
    .AddSingleton<INotificationService, EmailSenderService>()
    .AddSingleton<INotificationService, SmsSenderService>()
    .AddSingleton<INotificationService, TelegramSenderService>()
    .AddSingleton<BonusEventStore>()
    .AddSingleton<OrderEventStore>()
    .AddSingleton<IUserBonusService, UserBonusService>()
    .AddSingleton<IUserPromotionService, UserPromotionService>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var userBonusService = app.Services.GetRequiredService<IUserBonusService>();
var userPromotionService = app.Services.GetService<IUserPromotionService>();

app.MapControllers();

app.Run();
