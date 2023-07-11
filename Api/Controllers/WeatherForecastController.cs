using ControllerService.Weather;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> logger;
    private readonly IWeatherForecastService weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
    {
        this.logger = logger;
        this.weatherForecastService = weatherForecastService;
    }

    [HttpGet("GetCurrentWeather/{city}")]
    public async Task<CurrentWeatherModel> GetCurrentWeather(string city)
    {
        return await weatherForecastService.GetCurrentWeatherAsync(city);
    }

    [HttpGet("GetWeatherForecast")]
    public async Task<WeatherForecastModel> GetWeatherForecast([FromQuery] string city, [FromQuery] int daysAhead)
    {
        return await weatherForecastService.GetWeatherForecastAsync(city, daysAhead);
    }
}
