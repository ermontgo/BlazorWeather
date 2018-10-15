using Blazor.Fluxor;
using BlazorWeather.Api.Contracts;
using System.Collections.Generic;

namespace BlazorWeather.Client.Store
{
    public class GetWeatherReportsCompleteAction : IAction
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public List<WeatherReport> WeatherReports { get; set; }

        public GetWeatherReportsCompleteAction(List<WeatherReport> weatherReports)
        {
            WeatherReports = weatherReports;
            IsSuccess = true;
        }

        public GetWeatherReportsCompleteAction(string error)
        {
            Error = error;
            IsSuccess = false;
        }
    }
}
