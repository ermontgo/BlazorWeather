using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Fluxor;

namespace BlazorWeather.Client.Store.Reducers
{
    public class GetStadiumsCompleteReducer : Reducer<AppState, GetStadiumsCompleteAction>
    {
        public override AppState Reduce(AppState state, GetStadiumsCompleteAction action)
        {
            var newState = new AppState() { Conditions = state.Conditions, Reports = state.Reports, Stadiums = state.Stadiums, IsError = state.IsError };

            if (action.IsSuccess)
            {
                newState.Stadiums = action.Stadiums;
            }
            else
            {
                newState.IsError = action.Error;
            }

            return newState;
        }
    }
}
