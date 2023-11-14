using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using N64_T2.Identity.Application.Common.Identity.Services;
using N64_T2.Identity.Application.Common.Notifications.Servcies;
using N64_T2.Identity.Application.Common.Settings;
using N64_T2.Identity.Infrastructure.Common.Identity.Services;
using N64_T2.Identity.Infrastructure.Common.Notifucations.Services;
using N64_T2.Identity.Persistence.DataContexts;
using N64_T2.Identity.Persistence.Repositories;
using N64_T2.Identity.Persistence.Repositories.Interfaces;
using System.Text;

namespace N64_T1.Identity.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddHttpContextProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        return builder;
    }
    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IdentityDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrustructure(this WebApplicationBuilder builder)
    {
        builder.Services
            .Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)))
            .Configure<VerificationTokenSettings>(builder.Configuration.GetSection(nameof(VerificationTokenSettings)));

        builder.Services.AddDataProtection();

        builder.Services
            .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
            .AddTransient<IPasswordHasherService, PasswordHasherService>()
            .AddTransient<IVerificationTokenGeneratorService, VerificationTokenGeneratorService>();

        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IAccessTokenRepository, AccessTokenRepository>();

        builder.Services
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IAccessTokenService, AccessTokenService>()
            .AddScoped<IRoleService, RoleService>();

       var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

        builder
            .Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidateAudience = jwtSettings.ValidateAudiance,
                    ValidAudience = jwtSettings.ValidAudience,
                    ValidateLifetime = jwtSettings.ValidateLifeTime,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });


        return builder;
    }

    private static WebApplicationBuilder AddNotificationInfrustructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<EmailSenderSettings>(builder.Configuration.GetSection(nameof(EmailSenderSettings)));

        builder.Services.AddScoped<IEmailOrchestrationService, EmailOrchestrationService>();

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
    private static WebApplication UseIdentityInfrustructure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
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

}
