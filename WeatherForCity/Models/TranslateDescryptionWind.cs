using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public class TranslateDescryptionWind
    {

        public static readonly Dictionary<string, string> TranslateDescription = new Dictionary<string, string>
        {
            { "North" , "północny" },
            { "South" , "południowy" },
            { "East" , "wschodni" },
            { "West" , "zachodni" },
            { "NorthEast" , "północno-wschodni" },
            { "North-northeast" , "północno-wschodni" },
            { "East-southeast" , "południowo-wschodni" },
            { "Northwest" , "północno-zachodni" },
            { "West-northwest" , "północno-zachodni" },
            { "SouthEast" , "południowo-wschodni" },
            { "East-northeast" , "północno-wschodni" },
            { "South-southwest" , "południowo-zachodni" }
        };
    }
}
