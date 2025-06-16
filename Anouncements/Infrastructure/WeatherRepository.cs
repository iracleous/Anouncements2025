using Anouncements.Models;

namespace Anouncements.Infrastructure;

public class WeatherRepository : IWeatherRepository
{
    public Task AddWeatherForecastAsync(WeatherForecast weatherForecast)
    {
        throw new NotImplementedException();
    }

    public IQueryable<WeatherForecast> GetWeatherForecasts()
    {
        throw new NotImplementedException();
    }
}
