using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Api.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Get()
        {
            return BadRequest();
        }
    }
}
