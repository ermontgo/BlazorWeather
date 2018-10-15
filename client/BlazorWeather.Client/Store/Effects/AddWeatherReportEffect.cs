using Blazor.Fluxor;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWeather.Client.Store
{
    public class AddWeatherReportEffect : Effect<AddReportAction>
    {
        private readonly HttpClient client;

        public AddWeatherReportEffect(HttpClient client)
        {
            this.client = client;
        }

        protected override async Task HandleAsync(AddReportAction action, IDispatcher dispatcher)
        {
            try
            {
                await client.PostJsonAsync("http://localhost:5001/api/weather", action.Report);
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new AddWeatherReportCompleteAction(ex.Message));
            }
        }
    }
}
