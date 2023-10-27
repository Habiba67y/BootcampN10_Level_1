using N63_T2.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<AuthService>();
builder.Services.AddTransient<TokenGenerateService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
