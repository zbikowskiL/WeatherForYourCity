using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public class TimeTempPrecipitation
    {
        public string Time { get; set; }
        public int Temperature { get; set; }
        public string TemperatureDescryption { get; set; }
        public double Precipitation { get; set; }
        public string PrecipitationDescryption { get; set; }
        public static List<TimeTempPrecipitation> TimeTempPrecipitationList = new List<TimeTempPrecipitation>();
    }
}
