namespace ServiceGateway.Dtos.Weather
{
    public class WeatherForecastRequest
    {
        public required string City { get; init; }
        public required int DaysAhead { get; init; }

        public bool ReturnAirQualityData { get; init; }
        public string AirQualityData => ReturnAirQualityData ? "yes" : "no";

        public bool ReturnAlerts { get; init; }
        public string Alerts => ReturnAlerts ? "yes" : "no";
    }
}
