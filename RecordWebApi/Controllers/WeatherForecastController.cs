using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecordWebApi.Db;

namespace RecordWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Post()
        {
            using var db = new WeatherContext();

            var rng = new Random();
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast(
                DateTime.Now.AddDays(index),
                rng.Next(-20, 55),
                Summaries[rng.Next(Summaries.Length)])).ToArray();

            db.Weathers.AddRange(forecasts);
            db.SaveChanges();
        }

        [HttpGet("saved")]
        public IEnumerable<WeatherForecast> GetSaved()
        {
            using var db = new WeatherContext();
            return db.Weathers.ToArray();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast(
                DateTime.Now.AddDays(index),
                    rng.Next(-20, 55), 
                Summaries[rng.Next(Summaries.Length)])).ToArray();
        }
    }
}
