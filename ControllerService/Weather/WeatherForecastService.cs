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
        var result = await weatherForecast.GetAsync(new WeatherForecastRequest { City = city, DaysAhead = 1 });
        return MapToCurrentWeatherModel(result);
    }

    public async Task<WeatherForecastModel> GetWeatherForecastAsync(string city, int daysAhead)
    {
        var result = await weatherForecast.GetAsync(new WeatherForecastRequest { City = city, DaysAhead = daysAhead });
        return MapToWeatherForecastModel(result);
    }

    private CurrentWeatherModel MapToCurrentWeatherModel(WeatherForecastResponse weatherForecastResponse) => 
        new CurrentWeatherModel {
            City = weatherForecastResponse.Location.Name,
            Country = weatherForecastResponse.Location.Country,
            TempC = weatherForecastResponse.Current.TempC,
            Text = weatherForecastResponse.Current.Condition.Text,
            Icon = weatherForecastResponse.Current.Condition.Icon
            };

    private WeatherForecastModel MapToWeatherForecastModel(WeatherForecastResponse weatherForecastResponse) =>
        new WeatherForecastModel
        {
            City = weatherForecastResponse.Location.Name,
            Country = weatherForecastResponse.Location.Country,
            Days = weatherForecastResponse.Forecast.Forecastday.Select(x => new WeatherForecastModel.DayModel {
                Date = x.Date,
                MaxtempC = x.Day.MaxtempC,
                MintempC = x.Day.MintempC,
                AvgtempC = x.Day.AvgtempC,
                MaxwindKph = x.Day.MaxwindKph,
                TotalprecipMm = x.Day.TotalprecipMm,
                TotalsnowCm = x.Day.TotalsnowCm,
                Avghumidity = x.Day.Avghumidity,
                DailyChanceOfRain = x.Day.DailyChanceOfRain,
                DailyChanceOfSnow = x.Day.DailyChanceOfSnow,
                Text = x.Day.Condition.Text,
                Icon = x.Day.Condition.Icon,
                Uv = x.Day.Uv
                }).ToList()
        };
}
