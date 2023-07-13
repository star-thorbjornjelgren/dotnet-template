namespace ControllerService.Models.Weather
{
    public class WeatherForecastModel
    {
        public required string City { get; init; }
        public required string Country { get; init; }
        public required List<DayModel> Days { get; init; }

        public class DayModel
        {
            public required DateTime Date { get; init; }
            public required double MaxtempC { get; init; }
            public required double MintempC { get; init; }
            public required double AvgtempC { get; init; }
            public required double MaxwindKph { get; init; }
            public required double TotalprecipMm { get; init; }
            public required double TotalsnowCm { get; init; }
            public required double Avghumidity { get; init; }
            public required int DailyChanceOfRain { get; init; }
            public required int DailyChanceOfSnow { get; init; }
            public required string? Text { get; init; }
            public required string? Icon { get; init; }
            public required double Uv { get; init; }
        }
    }
}
