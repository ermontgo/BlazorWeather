using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeather.Api.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherReport>().HasIndex(wr => wr.EmailAddress);
            modelBuilder.Entity<WeatherReport>().HasIndex(wr => wr.ReportTime);
            
            var seeder = new StadiumSeeder();
            seeder.Seed(modelBuilder.Entity<Stadium>());
        }

        public DbSet<WeatherReport> WeatherReports { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
    }
}
