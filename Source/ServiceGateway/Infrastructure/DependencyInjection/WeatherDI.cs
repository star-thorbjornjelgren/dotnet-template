using Microsoft.Extensions.DependencyInjection;
using ServiceGateway.Configuration;
using ServiceGateway.Weather;

namespace ServiceGateway.Infrastructure.DependencyInjection
{
    public static class WeatherDI
    {
        public static void Apply(IServiceCollection services, WeatherConfig weatherConfig)
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
}
