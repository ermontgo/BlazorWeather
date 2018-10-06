using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Api.Models
{
    public class WeatherReport
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public Stadium Stadium { get; set; }

        public DateTimeOffset ReportTime { get; set; }

        public string WeatherDescription { get; set; }
        public decimal TemperatureDegreesFahrenheit { get; set; }

        public string EmailAddress { get; set; }
    }
}
