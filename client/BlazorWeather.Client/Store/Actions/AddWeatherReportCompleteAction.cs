using Blazor.Fluxor;
using BlazorWeather.Api.Contracts;

namespace BlazorWeather.Client.Store
{
    public class AddWeatherReportCompleteAction : IAction
    {
        public WeatherReport Report { get; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }

        public AddWeatherReportCompleteAction(WeatherReport report)
        {
            Report = report;
            IsSuccess = true;
        }

        public AddWeatherReportCompleteAction(string error)
        {
            Error = error;
            IsSuccess = false;
        }
    }
}
