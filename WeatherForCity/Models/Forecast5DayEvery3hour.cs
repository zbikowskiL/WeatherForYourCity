using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public class Forecast5DayEvery3Hour
    {
        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("dt")]
        public long Date { get; set; }

        [JsonProperty("dt_txt")]
        public string DateEvery3Hour { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }
    }
}
