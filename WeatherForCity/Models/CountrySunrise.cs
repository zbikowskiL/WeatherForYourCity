﻿using Newtonsoft.Json;

namespace WeatherForCity.Models
{
    public class CountrySunrise
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("message")]
        public double Message { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }

        [JsonProperty("sunset")]
        public long Sunset { get; set; }
    }
}