using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public class Weather5DayEvery3Hour
    {
        public string CityName { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public long Humidity { get; set; }
        public long Pressure { get; set; }
        public string Description { get; set; }
        public int CloudsPrecent { get; set; }
        public string IconName { get; set; }
        public string TimeAndTemp { get; set; }
        public double Precipitation { get; set; }
        public string WindDirection { get; set; }

        public Weather5DayEvery3Hour()
        {

        }
    }
}
