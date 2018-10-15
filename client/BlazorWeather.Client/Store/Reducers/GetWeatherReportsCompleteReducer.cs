using Blazor.Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Client.Store
{
    public class GetWeatherReportsCompleteReducer : Reducer<AppState, GetWeatherReportsCompleteAction>
    {
        public override AppState Reduce(AppState state, GetWeatherReportsCompleteAction action)
        {
            var newState = new AppState() { Conditions = state.Conditions, Reports = state.Reports, Stadiums = state.Stadiums, IsError = state.IsError };

            if (action.IsSuccess)
            {
                newState.Reports = action.WeatherReports;
            }
            else
            {
                newState.IsError = action.Error;
            }

            return newState;
        }
    }
}
