using System;

namespace RecordWebApi
{
    public record WeatherForecast2(Guid id, DateTime Date, int TemperatureC, string Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
