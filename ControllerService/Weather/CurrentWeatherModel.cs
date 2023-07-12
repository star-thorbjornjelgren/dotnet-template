namespace ControllerService.Weather;

public class CurrentWeatherModel
{
    public required string City { get; init; }
    public required string Country { get; init; }
    public required double TempC { get; init; }
    public required string? Text { get; init; }
    public required string? Icon { get; init; }
}
