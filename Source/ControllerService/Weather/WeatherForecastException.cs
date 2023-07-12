﻿namespace ControllerService.Weather
{
    public class WeatherForecastException : Exception
    {
        public WeatherForecastException(string? message) : base(message)
        {
        }

        public WeatherForecastException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
