using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RecordWebApi.Db;

namespace RecordWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMapper _mapper;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewContact, Contact>();
                cfg.CreateMap<Contact, NewContact>();
            });
            _mapper = config.CreateMapper();
        }

        [HttpPost("v1")]
        public void Post1()
        {
            using var db = new WeatherContext();

            var rng = new Random();
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast1(
                DateTime.Now.AddDays(index),
                rng.Next(-20, 55),
                Summaries[rng.Next(Summaries.Length)])).ToArray();

            db.Weathers1.AddRange(forecasts);
            db.SaveChanges();
        }

        [HttpGet("v1/saved")]
        public IEnumerable<WeatherForecast1> GetSaved1()
        {
            using var db = new WeatherContext();
            return db.Weathers1.ToArray();
        }

        [HttpPost("contacts")]
        public async Task<ActionResult<Contact>> PostContact([FromBody] NewContact newContact)
        {
            var contact = _mapper.Map<Contact>(newContact);

            using var db = new WeatherContext();
            db.Contacts.Add(contact);
            await db.SaveChangesAsync();

            return CreatedAtAction("Post", new { id = contact.Id }, _mapper.Map<Contact>(contact));
        }

        [HttpGet("contacts")]
        public async Task<ActionResult<Contact>> GetContact()
        {
            await using var db = new WeatherContext();
            var contacts = db.Contacts.ToArray();
            return Ok(contacts);
        }

        //[HttpPost("v2")]
        //public void Post2()
        //{
        //    using var db = new WeatherContext();

        //    var rng = new Random();
        //    var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast2 { Id = Guid.NewGuid()}).ToArray();

        //    db.Weathers2.AddRange(forecasts);
        //    db.SaveChanges();
        //}

        //[HttpGet("v2/saved")]
        //public IEnumerable<WeatherForecast2> GetSaved2()
        //{
        //    using var db = new WeatherContext();
        //    return db.Weathers2.ToArray();
        //}
    }
}
