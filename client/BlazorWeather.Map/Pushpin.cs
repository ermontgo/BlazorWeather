﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Map
{
    public class Pushpin
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Color { get; set; }
    }
}
