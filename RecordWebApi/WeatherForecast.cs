using System;

namespace RecordWebApi
{
    public record WeatherForecast(DateTime Date, int TemperatureC, string Summary)
    {
        public long Id { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
