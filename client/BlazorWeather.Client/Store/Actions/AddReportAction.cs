using Blazor.Fluxor;
using BlazorWeather.Api.Contracts;

namespace BlazorWeather.Client.Store
{
    public class AddReportAction : IAction
    {
        public AddReportAction(WeatherReport report)
        {
            Report = report;
        }

        public WeatherReport Report { get; }
    }
}
