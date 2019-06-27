using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public class Response5DayEvery3Hour
    {
        [JsonProperty("list")]
        public List<Forecast5DayEvery3Hour> Forecast5DayEvery3HourList { get; set; }

    }
}
