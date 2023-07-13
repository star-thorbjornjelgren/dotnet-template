using System.Text.Json.Serialization;

namespace ServiceGateway.Dtos.Weather
{
    public class WeatherForecastResponse
    {
        public required GeoLocation Location { get; init; }

        public required CurrentWeather Current { get; init; }

        public required WeatherForecast Forecast { get; init; }


        public class GeoLocation
        {
            public required string Name { get; init; }
            public required string Region { get; init; }
            public required string Country { get; init; }
            public double Lat { get; init; }
            public double Lon { get; init; }
            public string? TzId { get; init; }
            public long LocaltimeEpoch { get; init; }
            public string? Localtime { get; init; }
        }

        public class Condition
        {
            public string? Text { get; init; }
            public string? Icon { get; init; }
            public int Code { get; init; }
        }

        public class CurrentWeather
        {
            public long LastUpdatedEpoch { get; init; }
            public string? LastUpdated { get; init; }
            [JsonPropertyName("temp_c")]
            public double TempC { get; init; }
            public double TempF { get; init; }
            public int IsDay { get; init; }
            public required Condition Condition { get; init; }
            public double WindMph { get; init; }
            public double WindKph { get; init; }
            public int WindDegree { get; init; }
            public string? WindDir { get; init; }
            public double PressureMb { get; init; }
            public double PressureIn { get; init; }
            public double PrecipMm { get; init; }
            public double PrecipIn { get; init; }
            public int Humidity { get; init; }
            public int Cloud { get; init; }
            public double FeelslikeC { get; init; }
            public double FeelslikeF { get; init; }
            public double VisKm { get; init; }
            public double VisMiles { get; init; }
            public double Uv { get; init; }
            public double GustMph { get; init; }
            public double GustKph { get; init; }
        }

        public class Day
        {
            [JsonPropertyName("maxtemp_c")]
            public double MaxtempC { get; init; }
            public double MaxtempF { get; init; }
            [JsonPropertyName("mintemp_c")]
            public double MintempC { get; init; }
            public double MintempF { get; init; }
            [JsonPropertyName("avgtemp_c")]
            public double AvgtempC { get; init; }
            public double AvgtempF { get; init; }
            public double MaxwindMph { get; init; }
            [JsonPropertyName("maxwind_kph")]
            public double MaxwindKph { get; init; }
            [JsonPropertyName("totalprecip_mm")]
            public double TotalprecipMm { get; init; }
            public double TotalprecipIn { get; init; }
            [JsonPropertyName("totalsnow_cm")]
            public double TotalsnowCm { get; init; }
            public double AvgvisKm { get; init; }
            public double AvgvisMiles { get; init; }
            public double Avghumidity { get; init; }
            public int DailyWillItRain { get; init; }
            [JsonPropertyName("daily_chance_of_rain")]
            public int DailyChanceOfRain { get; init; }
            public int DailyWillItSnow { get; init; }
            [JsonPropertyName("daily_chance_of_snow")]
            public int DailyChanceOfSnow { get; init; }
            public required Condition Condition { get; init; }
            public double Uv { get; init; }
        }

        public class Astro
        {
            public string? Sunrise { get; init; }
            public string? Sunset { get; init; }
            public string? Moonrise { get; init; }
            public string? Moonset { get; init; }
            public string? MoonPhase { get; init; }
            public string? MoonIllumination { get; init; }
            public int IsMoonUp { get; init; }
            public int IsSunUp { get; init; }
        }

        public class Hour
        {
            public long TimeEpoch { get; init; }
            public string? Time { get; init; }
            public double TempC { get; init; }
            public double TempF { get; init; }
            public int IsDay { get; init; }
            public required Condition Condition { get; init; }
            public double WindMph { get; init; }
            public double WindKph { get; init; }
            public int WindDegree { get; init; }
            public string? WindDir { get; init; }
            public double PressureMb { get; init; }
            public double PressureIn { get; init; }
            public double PrecipMm { get; init; }
            public double PrecipIn { get; init; }
            public int Humidity { get; init; }
            public int Cloud { get; init; }
            public double FeelslikeC { get; init; }
            public double FeelslikeF { get; init; }
            public double WindchillC { get; init; }
            public double WindchillF { get; init; }
            public double HeatindexC { get; init; }
            public double HeatindexF { get; init; }
            public double DewpointC { get; init; }
            public double DewpointF { get; init; }
            public int WillItRain { get; init; }
            public int ChanceOfRain { get; init; }
            public int WillItSnow { get; init; }
            public int ChanceOfSnow { get; init; }
            public double VisKm { get; init; }
            public double VisMiles { get; init; }
            public double GustMph { get; init; }
            public double GustKph { get; init; }
            public double Uv { get; init; }
        }

        public class Forecastday
        {
            public DateTime Date { get; init; }
            public long DateEpoch { get; init; }
            public required Day Day { get; init; }
            public required Astro Astro { get; init; }
            public required List<Hour> Hour { get; init; }
        }

        public class WeatherForecast
        {
            public required List<Forecastday> Forecastday { get; init; }
        }
    }
}
