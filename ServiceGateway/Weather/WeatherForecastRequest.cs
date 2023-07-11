namespace ServiceGateway.Weather
{
    public class WeatherForecastRequest
    {
        public WeatherForecastRequest(string city, int daysAhead, bool airQualityData, bool alerts)
        {
            City = city;
            DaysAhead = daysAhead;
            this.airQualityData = airQualityData;
            this.alerts = alerts;
        }

        public string City { get; }
        public int DaysAhead { get; }

        private bool airQualityData { get; }
        public string AirQualityData => airQualityData ? "yes" : "no";

        private bool alerts { get; }
        public string Alerts => alerts ? "yes" : "no";
    }
}
