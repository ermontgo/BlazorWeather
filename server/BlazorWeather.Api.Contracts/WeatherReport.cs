using System;

namespace BlazorWeather.Api.Contracts
{
    public class WeatherReport
    {
        public string Stadium { get; set; }

        public DateTimeOffset ReportTime { get; set; }

        public string WeatherDescription { get; set; }
        public decimal TemperatureDegreesFahrenheit { get; set; }

        public string EmailAddress { get; set; }
    }
}
