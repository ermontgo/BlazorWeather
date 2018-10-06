using BlazorWeather.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Api.Controllers
{
    [Route("~/api/weather")]
    public class WeatherController : Controller
    {
        private readonly WeatherContext context;

        public WeatherController(WeatherContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await context.Stadiums.Include(s => s.CurrentWeather).Select(s => new Contracts.WeatherReport() {
                Stadium = s.Name,
                StadiumLogo = s.Logo,
                Latitude = s.Location.Y,
                Longitude = s.Location.X,
                ReportTime = s.CurrentWeather != null ? s.CurrentWeather.ReportTime : (DateTimeOffset?)null,
                TemperatureDegreesFahrenheit = s.CurrentWeather != null ? s.CurrentWeather.TemperatureDegreesFahrenheit : (decimal?)null,
                WeatherDescription = s.CurrentWeather != null ? s.CurrentWeather.WeatherDescription : null,
                EmailAddress = s.CurrentWeather.EmailAddress
            }).ToListAsync();

            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contracts.WeatherReport weatherReport)
        {
            var stadium = await context.Stadiums.Where(s => s.Name == weatherReport.Stadium).FirstOrDefaultAsync();

            if (stadium == null) return BadRequest($"No stadium could be found by name {weatherReport.Stadium}");

            var model = new WeatherReport()
            {
                CreatedDate = DateTimeOffset.Now,
                EmailAddress = weatherReport.EmailAddress,
                ReportTime = weatherReport.ReportTime.Value,
                Stadium = stadium,
                TemperatureDegreesFahrenheit = weatherReport.TemperatureDegreesFahrenheit.Value,
                WeatherDescription = weatherReport.WeatherDescription
            };

            stadium.CurrentWeather = model;

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
