using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecordWebApi.Db
{
    public class WeatherContext : DbContext
    {
        public DbSet<WeatherForecast1> Weathers1 { get; set; }
        public DbSet<WeatherForecast2> Weathers2 { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=Weathers.db;");
        }
    }
}
