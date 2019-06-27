using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public class HourlyWeather
    {
        [JsonProperty("list")]
        public List<HourlyForecast> HourlyForecastList { get; set; }

        [JsonProperty("city")]
        public CityInformation CityInformation { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }

        [JsonProperty("cnt")]
        public long Cnt { get; set; }
    }

}
