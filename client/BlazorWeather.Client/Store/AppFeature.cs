using Blazor.Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Client.Store
{
    public class AppFeature : Feature<AppState>
    {
        public override string GetName() => "App";
        protected override AppState GetInitialState() => new AppState() { Conditions = new List<string> { "Rain", "Snow", "Overcast", "Sunny" } };
    } 
}
