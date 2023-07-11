namespace ControllerService.Weather
{
    /// <summary>
    /// Name WeatherForecastService matches the name of controller WeatherForecastController
    /// </summary>
    public interface IWeatherForecastService
    {
        /// <summary>
        /// Names matches the name of actions in the WeatherForecastController + Async (if it is actually async)
        /// </summary>
        Task<CurrentWeatherModel> GetCurrentWeatherAsync(string city);
        Task<WeatherForecastModel> GetWeatherForecastAsync(string city, int daysAhead);
        
    }
}
