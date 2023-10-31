using N66_HT1.Application.Authors;
using N66_HT1.Application.Books;
using N66_HT1.Infrastructure.Authors;
using N66_HT1.Infrastructure.Books;
using N66_HT1.Persistence.DataContexts;
using N66_HT1.Persistence.SeedData;

namespace N66_HT1.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddInfrustructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IDbContext, AppDbContext>();

        builder.Services
            .AddScoped<IAuthorService, AuthorService>()
            .AddScoped<IBookService, BookService>();

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

    private static async ValueTask<WebApplication> UseDbContext(this WebApplication app)
    {
        await app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<IDbContext>().InitializeSeedDataAsync();

        return app;
    }
}