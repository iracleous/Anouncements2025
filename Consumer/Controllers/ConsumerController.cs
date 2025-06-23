using Anouncements.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Controllers;

[ApiController]
[Route("[controller]")]
public class ConsumerController : ControllerBase
{

    private readonly HttpClient _httpClient;

    public ConsumerController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }



    [HttpGet]
    public async Task<ActionResult<List<WeatherForecast>>> Get()
    {
        string url = "https://localhost:7191/weatherforecast";
        var response = await _httpClient.GetAsync(url); 
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
            return Ok(data);
        }
        else
        {
            return StatusCode((int)response.StatusCode, "Error fetching data from the API.");
        }



    }
}
