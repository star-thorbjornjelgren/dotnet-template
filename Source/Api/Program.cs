using ControllerService.Weather;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
var corsPolicyName = "STAR_CORS_POLICY";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
                      policy =>
                      {
                          policy.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()!);
                      });
});

// Dependency Injection
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

// Dependency injection for underlying projects
ControllerService.Infrastructure.DependencyInjection.WeatherDI.Apply(builder.Services, builder.Configuration["Weather:Url"]!, builder.Configuration["Weather:ApiKey"]!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
