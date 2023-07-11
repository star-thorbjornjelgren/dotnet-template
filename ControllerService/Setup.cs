using ControllerService.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceGateway.CurrentWeather;
using ServiceGateway.Weather;

namespace ControllerService;

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
