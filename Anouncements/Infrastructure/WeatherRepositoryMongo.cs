using Anouncements.Models;

namespace Anouncements.Infrastructure;

public class WeatherRepositoryMongo : IWeatherRepository
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
