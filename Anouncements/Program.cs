using Anouncements.Factory;
using Anouncements.Infrastructure;
using Anouncements.Services;
using Anouncements.Singleton;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddDbContext<Data>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddSingleton<IAppConfigService, AppConfigService>();
builder.Services.AddSingleton<INotifierFactory, NotifierFactory>();




var app = builder.Build();

// Configure the HTTP request pipeline.


// --- Automatic Migration Logic ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<Data>();
        context.Database.Migrate();
        // You can also add seed data here if needed
        // await SeedData.Initialize(services); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
        // Consider re-throwing the exception or taking other action
    }
}
// --- End Automatic Migration Logic ---




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
