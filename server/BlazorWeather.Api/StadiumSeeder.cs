using BlazorWeather.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Api
{
    public class StadiumSeeder
    {
        public void Seed(EntityTypeBuilder<Stadium> builder)
        {
            var definition = new[] { new { Id = 0, Team = "", Lat = 0.0, Lng = 0.0, Logo = string.Empty } };
            var file = File.ReadAllText("stadiums.json");

            var stadiums = JsonConvert.DeserializeAnonymousType(file, definition);

            builder.HasData(stadiums.Select(s => new { s.Id, Name = s.Team, Location = new Point(s.Lng, s.Lat), s.Logo }));
        }
    }
}
