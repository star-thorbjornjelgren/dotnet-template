namespace ControllerService.Weather
{
    public class WeatherForecastModel
    {
        public WeatherForecastModel(string city, string country, List<DayModel> days)
        {
            City = city;
            Country = country;
            Days = days;
        }

        public string City { get; }
        public string Country { get; }
        public List<DayModel> Days { get; }

        public class DayModel
        {
            public DayModel(DateTime date, double maxtempC, double mintempC, double avgtempC, double maxwindKph, double totalprecipMm, double totalsnowCm, double avghumidity, int dailyChanceOfRain, int dailyChanceOfSnow, string? text, string? icon, double uv)
            {
                Date = date;
                MaxtempC = maxtempC;
                MintempC = mintempC;
                AvgtempC = avgtempC;
                MaxwindKph = maxwindKph;
                TotalprecipMm = totalprecipMm;
                TotalsnowCm = totalsnowCm;
                Avghumidity = avghumidity;
                DailyChanceOfRain = dailyChanceOfRain;
                DailyChanceOfSnow = dailyChanceOfSnow;
                Text = text;
                Icon = icon;
                Uv = uv;
            }

            public DateTime Date { get; }
            public double MaxtempC { get; }
            public double MintempC { get; }
            public double AvgtempC { get; }
            public double MaxwindKph { get; }
            public double TotalprecipMm { get; }
            public double TotalsnowCm { get; }
            public double Avghumidity { get; }
            public int DailyChanceOfRain { get; }
            public int DailyChanceOfSnow { get; }
            public string? Text { get; }
            public string? Icon { get; }
            public double Uv { get; }
        }
    }
}
