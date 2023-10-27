using FileBaseContext.Context.Models.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using N63_HT1.Constants;
using N63_HT1.Data;
using N63_HT1.Models.Settings;
using N63_HT1.Services;
using N63_HT1.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));
builder.Services.Configure<FileStorageSettings>(builder.Configuration.GetSection(nameof(FileStorageSettings)));

builder.Services.AddScoped<IDataContext, AppFileContext>(provider =>
{
    var options = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "Storage")
    };
    var dataContext = new AppFileContext(options);
    dataContext.FetchAsync().AsTask().Wait();

    return dataContext;
});

builder.Services
    .AddTransient<ITokenGenerateService, TokenGenerateService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IStorageFileService, StorageFileService>()
    .AddScoped<IAuthService, AuthService>()
    .AddScoped<IFileService, FileService>();

builder.Services.AddControllers();

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
            ValidateAudience =jwtSettings.ValidateAudiance,
            ValidAudience = jwtSettings.ValidAudience,
            ValidateLifetime = jwtSettings.ValidateLifeTime,
            ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(SwaggerConstants.SecurityDefinitionName, new OpenApiSecurityScheme
    {
        Name = SwaggerConstants.SecuritySchemeName,
        Type = SecuritySchemeType.ApiKey,
        Scheme = SwaggerConstants.SecurityScheme,
        In = ParameterLocation.Header,
        Description = SwaggerConstants.SwaggerAuthorizationDescription
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = SwaggerConstants.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
