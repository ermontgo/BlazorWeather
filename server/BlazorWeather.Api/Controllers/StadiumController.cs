using BlazorWeather.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorWeather.Api.Controllers
{
    [Route("~/api/stadiums")]
    public class StadiumController : Controller
    {
        private readonly WeatherContext context;

        public StadiumController(WeatherContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Contracts.Stadium> result = await context.Stadiums.Select(s => new Contracts.Stadium()
            {
                Name = s.Name,
                Logo = s.Logo
            }).ToListAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("closest")]
        public async Task<IActionResult> GetClosestStadium(double lat, double lon)
        {
            var geom = Geometry.DefaultFactory.CreatePoint(new GeoAPI.Geometries.Coordinate(lon, lat));
            var closestStadium = await context.Stadiums.OrderBy(s => s.Location.Distance(geom)).FirstOrDefaultAsync();

            var result = new Contracts.Stadium()
            {
                Name = closestStadium.Name,
                Logo = closestStadium.Logo
            };

            return Ok(result);
        }
    }
}
