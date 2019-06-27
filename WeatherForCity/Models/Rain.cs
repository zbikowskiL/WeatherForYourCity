using Newtonsoft.Json;

namespace WeatherForCity.Models
{
    public class Rain
    {
        public int invalid_name__3h { get; set; }

        [JsonProperty("1h", NullValueHandling = NullValueHandling.Ignore)]
        public double? The1H { get; set; }

        [JsonProperty("3h")]
        public double Rain3h { get; set; }
    }
}