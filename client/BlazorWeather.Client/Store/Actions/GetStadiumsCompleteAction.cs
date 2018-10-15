using Blazor.Fluxor;
using BlazorWeather.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Client.Store
{

    public class GetStadiumsCompleteAction : IAction
    {
        public List<Stadium> Stadiums { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }

        public GetStadiumsCompleteAction(List<Stadium> stadia)
        {
            Stadiums = stadia;
        }

        public GetStadiumsCompleteAction(string error)
        {
            Error = error;
        }
    }
}
