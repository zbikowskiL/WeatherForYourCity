using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int CloudsPrecent { get; set; }
    }
}
