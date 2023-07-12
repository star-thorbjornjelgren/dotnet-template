using Microsoft.Extensions.DependencyInjection;
using ServiceGateway.Configuration;

namespace ControllerService;

public static class Setup
{
    public static void SetupDependencyInjection(IServiceCollection services, dynamic weatherConfig)
    {
        ServiceGateway.Setup.SetupDependencyInjection(services, new WeatherConfig(weatherConfig.Url, weatherConfig.ApiKey));
    }
}
