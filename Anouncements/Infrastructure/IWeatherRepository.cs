using Anouncements.Models;

namespace Anouncements.Infrastructure;

public interface IWeatherRepository
{
    IQueryable<WeatherForecast> GetWeatherForecasts();
    Task AddWeatherForecastAsync(WeatherForecast weatherForecast);
}
