using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public class TimeAndTemp
    {
        public string Time { get; set; }
        public double Temperature { get; set; }
        public static List<TimeAndTemp> TimeAndTempList = new List<TimeAndTemp>();
    }
}
