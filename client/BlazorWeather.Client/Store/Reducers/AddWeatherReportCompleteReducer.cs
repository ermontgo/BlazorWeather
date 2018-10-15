using Blazor.Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Client.Store.Reducers
{
    public class AddWeatherReportCompleteReducer : Reducer<AppState, AddWeatherReportCompleteAction>
    {
        public override AppState Reduce(AppState state, AddWeatherReportCompleteAction action)
        {
            var newState = new AppState() { Conditions = state.Conditions, Reports = state.Reports, Stadiums = state.Stadiums, IsError = state.IsError };

            if (action.IsSuccess)
            {
                newState.Reports.Add(action.Report);
            }
            else
            {
                newState.IsError = action.Error;
            }

            return newState;
        }
    }
}
