using System.Text.Json;
using ServiceGateway.Dtos.Weather;
using ServiceGateway.Interfaces.Weather;

namespace ServiceGateway.Gateways.Weather;

public class WeatherForecastGateway : IWeatherForecastGateway
{
    public WeatherForecastGateway(HttpClient httpClient, string apiKey)
    {
        this.httpClient = httpClient;
        this.apiKey = apiKey;
    }

    private readonly HttpClient httpClient;
    private readonly string apiKey;

    public async Task<WeatherForecastResponse?> GetAsync(WeatherForecastRequest weatherForecastRequest)
    {
        var apiUrl = $"forecast.json?key={apiKey}&q={weatherForecastRequest.City}&days={weatherForecastRequest.DaysAhead}&aqi={weatherForecastRequest.AirQualityData}&alerts={weatherForecastRequest.Alerts}";

        var response = await httpClient.GetAsync(apiUrl);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to retrieve weather data. Status code: {response.StatusCode}", null, response.StatusCode);
        }

        var jsonString = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<WeatherForecastResponse>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
