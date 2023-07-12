namespace ServiceGateway.Configuration;

public class WeatherConfig
{
    public WeatherConfig(string url, string apiKey)
    {
        Url = url;
        ApiKey = apiKey;
    }

    public string Url { get; }
    public string ApiKey { get; }
}
