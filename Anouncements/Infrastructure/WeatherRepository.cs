using Anouncements.Models;

namespace Anouncements.Infrastructure;

public class WeatherRepository : IWeatherRepository
{

    private readonly Data _context;
    public WeatherRepository(Data context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task AddWeatherForecastAsync(WeatherForecast weatherForecast)
    {
        _context.WeatherForecasts.Add(weatherForecast);
        await _context.SaveChangesAsync();
    }

    public IQueryable<WeatherForecast> GetWeatherForecasts()
    {
        return _context.WeatherForecasts;
    }
}
