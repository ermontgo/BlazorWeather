using Blazor.Fluxor;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWeather.Client.Store
{
    public class GetStadiumsEffect : Effect<GetStadiumsAction>
    {
        private readonly HttpClient client;

        public GetStadiumsEffect(HttpClient client)
        {
            this.client = client;
        }

        protected override async Task HandleAsync(GetStadiumsAction action, IDispatcher dispatcher)
        {
            string url = "http://localhost:5001/api/stadiums";

            try
            {
                var response = await client.GetJsonAsync<List<Api.Contracts.Stadium>>(url);
                dispatcher.Dispatch(new GetStadiumsCompleteAction(response));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new GetStadiumsCompleteAction(ex.Message));
            }
        }
    }
}
