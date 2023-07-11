using ServiceGateway.Weather;

namespace ControllerService.Weather;


public class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherForecastGateway weatherForecast;

    public WeatherForecastService(IWeatherForecastGateway weatherForecast)
    {
        this.weatherForecast = weatherForecast;
    }

    public async Task<CurrentWeatherModel> GetCurrentWeatherAsync(string city)
    {
        var result = await weatherForecast.GetAsync(new WeatherForecastRequest(city, 1, false, false));
        return MapToCurrentWeatherModel(result);
    }

    public async Task<WeatherForecastModel> GetWeatherForecastAsync(string city, int daysAhead)
    {
        var result = await weatherForecast.GetAsync(new WeatherForecastRequest(city, daysAhead, false, false));
        return MapToWeatherForecastModel(result);
    }

    private CurrentWeatherModel MapToCurrentWeatherModel(WeatherForecastResponse weatherForecastResponse) => 
        new CurrentWeatherModel(
            weatherForecastResponse.Location.Name,
            weatherForecastResponse.Location.Country,
            weatherForecastResponse.Current.TempC,
            weatherForecastResponse.Current.Condition.Text,
            weatherForecastResponse.Current.Condition.Icon
            );

    private WeatherForecastModel MapToWeatherForecastModel(WeatherForecastResponse weatherForecastResponse) => 
        new WeatherForecastModel(
            weatherForecastResponse.Location.Name,
            weatherForecastResponse.Location.Country,
            weatherForecastResponse.Forecast.Forecastday.Select(x => new WeatherForecastModel.DayModel(
                x.Date,
                x.Day.MaxtempC,
                x.Day.MintempC,
                x.Day.AvgtempC,
                x.Day.MaxwindKph,
                x.Day.TotalprecipMm,
                x.Day.TotalsnowCm,
                x.Day.Avghumidity,
                x.Day.DailyChanceOfRain,
                x.Day.DailyChanceOfSnow,
                x.Day.Condition.Text,
                x.Day.Condition.Icon,
                x.Day.Uv
                )).ToList()
            );
}
