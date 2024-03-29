using Microsoft.AspNetCore.Mvc;

namespace LoggingBestPractices.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "weather")]
    public IEnumerable<WeatherForecast> Get([FromQuery] int days = 5)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            // Value types need to be boxed to be put in an object array
            // Arrays are also placed on the heap.
            _logger.LogDebug("Retrieving weather forecast for {Days} days", days);
        }
        return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}