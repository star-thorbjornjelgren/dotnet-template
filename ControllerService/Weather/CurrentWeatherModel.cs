namespace ControllerService.Weather
{
    public class CurrentWeatherModel
    {
        public CurrentWeatherModel(string city, string country, double tempC, string? text, string? icon)
        {
            City = city;
            Country = country;
            TempC = tempC;
            Text = text;
            Icon = icon;
        }

        public string City { get; }
        public string Country { get; }
        public double TempC { get; }
        public string? Text { get; }
        public string? Icon { get; }
    }
}
