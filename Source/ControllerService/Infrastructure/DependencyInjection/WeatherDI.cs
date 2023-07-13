using Microsoft.Extensions.DependencyInjection;
using ServiceGateway.Configuration;

namespace ControllerService.Infrastructure.DependencyInjection
{
    public static class WeatherDI
    {
        public static void Apply(IServiceCollection services, string url, string apiKey)
        {
            ServiceGateway.Infrastructure.DependencyInjection.WeatherDI.Apply(services, new WeatherConfig(url, apiKey));
        }
    }
}
