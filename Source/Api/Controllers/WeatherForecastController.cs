using ControllerService.Exceptions;
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

    [HttpGet("GetWeatherForecast")]
    public async Task<WeatherForecastModel?> GetWeatherForecast([FromQuery] string city, [FromQuery] int daysAhead)
    {
        try
        {
            var result = await weatherForecastService.GetWeatherForecastAsync(city, daysAhead);

            Response.StatusCode = StatusCodes.Status200OK;

            return result;
        }
        catch (DataNotFoundException) {
            Response.StatusCode = StatusCodes.Status404NotFound;
            return null;
        }
        catch (WeatherForecastException ex) {
            logger.LogError("Error when gettings weather forecast", ex);
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            return null;
        }
    }
}
