using System;

namespace BlazorWeather.Api.Contracts
{
    public class WeatherReport
    {
        public string Stadium { get; set; }
        public string StadiumLogo { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTimeOffset? ReportTime { get; set; }

        public string WeatherDescription { get; set; }
        public decimal? TemperatureDegreesFahrenheit { get; set; }

        public string EmailAddress { get; set; }
    }
}
