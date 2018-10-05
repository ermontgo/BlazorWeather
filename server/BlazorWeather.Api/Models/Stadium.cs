using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Api.Models
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Logo { get; set; }

        public Geometry Location { get; set; }
    }
}
