using ServiceGateway.Dtos.Weather;

namespace ServiceGateway.Interfaces.Weather;

public interface IWeatherForecastGateway
{
    Task<WeatherForecastResponse?> GetAsync(WeatherForecastRequest weatherForecastRequest);
}
