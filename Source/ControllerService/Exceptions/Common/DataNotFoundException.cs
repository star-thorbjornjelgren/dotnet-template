﻿namespace ControllerService.Exceptions.Common
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string? message) : base(message)
        {
        }
    }
}
