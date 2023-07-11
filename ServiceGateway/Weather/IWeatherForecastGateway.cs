namespace ServiceGateway.Weather;

public interface IWeatherForecastGateway
{
    Task<WeatherForecastResponse> GetAsync(WeatherForecastRequest weatherForecastRequest);
}
