using ControllerService.Exceptions;
using ServiceGateway.Weather;

namespace ControllerService.Weather;


public class WeatherForecastService : IWeatherForecastService
{
    private readonly IWeatherForecastGateway weatherForecast;

    public WeatherForecastService(IWeatherForecastGateway weatherForecast)
    {
        this.weatherForecast = weatherForecast;
    }

    public async Task<WeatherForecastModel> GetWeatherForecastAsync(string city, int daysAhead)
    {
        try
        {
            var result = await weatherForecast.GetAsync(new WeatherForecastRequest { City = city, DaysAhead = daysAhead });

            if (result == null)
            {
                throw new DataNotFoundException("Failed to get weather forecast. No results were found");
            }

            return MapToWeatherForecastModel(result);
        }
        catch(DataNotFoundException)
        {
            throw;
        }
        catch (Exception ex) {
            throw new WeatherForecastException("Error getting weather forecast", ex);
        }
    }

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
