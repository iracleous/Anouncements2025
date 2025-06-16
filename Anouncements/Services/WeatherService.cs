using Anouncements.Infrastructure;
using Anouncements.Models;
using Microsoft.EntityFrameworkCore;

namespace Anouncements.Services;

public class WeatherService : IWeatherService
{

    private readonly IWeatherRepository _weatherRepository;
    public WeatherService(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository ?? throw new ArgumentNullException(nameof(weatherRepository));
    }

    public async Task AddWeatherForecastAsync(WeatherForecast weatherForecast)
    {
        await _weatherRepository.AddWeatherForecastAsync(weatherForecast);
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync(int count = 5)
    {
        var query =  _weatherRepository.GetWeatherForecasts();
        return await query.Take(count).ToListAsync().ContinueWith(task => task.Result.AsEnumerable());
    }
}
