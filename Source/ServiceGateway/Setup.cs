using Microsoft.Extensions.DependencyInjection;
using ServiceGateway.Configuration;
using ServiceGateway.CurrentWeather;
using ServiceGateway.Weather;

namespace ServiceGateway;

public static class Setup
{
    public static void SetupDependencyInjection(IServiceCollection services, WeatherConfig weatherConfig)
    {
        services.AddSingleton<IWeatherForecastGateway>(new WeatherForecastGateway(
            new HttpClient
            {
                BaseAddress = new Uri(weatherConfig.Url)
            },
            weatherConfig.ApiKey
            ));
    }
}
