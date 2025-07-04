using Announcements.Security;
using Anouncements.Models;
using Anouncements.Services;
using Microsoft.AspNetCore.Mvc;

namespace Anouncements.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        return await _weatherService.GetWeatherForecastsAsync();
    }

  
    [HttpPost]
    [ApiKeyAuth]

    public async Task<ActionResult<WeatherForecast>> PostAsync([FromBody] WeatherForecast weatherForecast)
    {
        if (weatherForecast == null)
        {
            return BadRequest("Weather forecast cannot be null.");
        }
        await _weatherService.AddWeatherForecastAsync(weatherForecast);
        return Ok(weatherForecast);
    }

}

