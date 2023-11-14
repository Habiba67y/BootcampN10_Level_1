using Microsoft.EntityFrameworkCore;
using N71_HT1.Application.Common;
using N71_HT1.Infrastructure.Common;
using N71_HT1.Persistence.DataContexts;
using N71_HT1.Persistence.Repositories;
using N71_HT1.Persistence.Repositories.Interfaces;
using N71_HT1.Persistence.SeedData;

namespace N71_HT1.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IBlogRepository, BlogRepository>()
            .AddScoped<ICommentRepository, CommentRepository>();

        builder.Services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IBlogService, BlogService>()
            .AddScoped<ICommentService, CommentService>()
            .AddScoped<IBloggerManagementService, BloggerManagementService>();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static async ValueTask<WebApplication> UseSeedData(this WebApplication app)
    {
        await app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<AppDbContext>().InitializeSeedData();

        return app;
    }
}
