using Blazor.Fluxor;
using BlazorWeather.Api.Contracts;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWeather.Client.Store
{
    public class GetWeatherReportsEffect : Effect<GetWeatherReportsAction>
    {
        private readonly HttpClient client;

        public GetWeatherReportsEffect(HttpClient client)
        {
            this.client = client;
        }

        protected override async Task HandleAsync(GetWeatherReportsAction action, IDispatcher dispatcher)
        {
            string url = "http://localhost:5001/api/weather";
            try
            {
                var response = await client.GetJsonAsync<List<WeatherReport>>(url);
                dispatcher.Dispatch(new GetWeatherReportsCompleteAction(response));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new GetWeatherReportsCompleteAction(ex.Message));
                throw;
            }
        }
    }
}
