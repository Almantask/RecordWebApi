using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecordWebApi.Db
{
    public class WeatherContext : DbContext
    {
        public DbSet<WeatherForecast> Weathers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=Weathers.db;");
        }
    }
}
