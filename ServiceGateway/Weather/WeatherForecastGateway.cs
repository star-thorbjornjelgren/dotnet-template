using ServiceGateway.Weather;
using System.Text.Json;

namespace ServiceGateway.CurrentWeather;

public class WeatherForecastGateway : IWeatherForecastGateway
{
    public WeatherForecastGateway(HttpClient httpClient, string apiKey)
    {
        this.httpClient = httpClient;
        this.apiKey = apiKey;
    }

    private readonly HttpClient httpClient;
    private readonly string apiKey;

    public async Task<WeatherForecastResponse> GetAsync(WeatherForecastRequest weatherForecastRequest)
    {
        var apiUrl = $"forecast.json?key={apiKey}&q={weatherForecastRequest.City}&days={weatherForecastRequest.DaysAhead}&aqi=no&alerts=no";
        var response = await httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<WeatherForecastResponse>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (result == null)
                throw new Exception($"Status Ok but no data was retrieved");

            return result;
        }
        
        throw new Exception($"Failed to retrieve weather data. Status code: {response.StatusCode}");
    }
}
