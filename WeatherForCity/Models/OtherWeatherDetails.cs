using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public class OtherWeatherDetails
    {
        [JsonProperty("pod")]
        public TimeOfDay TimeOfDay { get; set; }
    }

    public enum TimeOfDay { D, N };

    public enum CloudyType { BrokenClouds, ClearSky, FewClouds, LightRain, ModerateRain, OvercastClouds, ScatteredClouds };

    public enum Icon { The01D, The02D, The03D, The04D, The04N, The10D, The10N };

    public enum MainEnum { Clear, Clouds, Rain };
    
}
