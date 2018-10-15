using BlazorWeather.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Client.Store
{
    public class AppState
    {
        public List<WeatherReport> Reports { get; set; } = new List<WeatherReport>();
        public List<Stadium> Stadiums { get; set; } = new List<Stadium>();
        public List<string> Conditions { get; set; } = new List<string>();

        public string IsError { get; set; }
    }
}
