using Anouncements.Models;

namespace Anouncements.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync(int count = 5);
    Task AddWeatherForecastAsync(WeatherForecast weatherForecast);
}
