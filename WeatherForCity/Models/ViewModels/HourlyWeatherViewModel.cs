using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models.ViewModels
{
    public class HourlyWeatherViewModel
    {
        public double Temperature { get; set; }
        public long Pressure { get; set; }
        public long Humidity { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public List<HourlyForecast> HourlyForecast { get; set; }

        public HourlyWeatherViewModel()
        {

        }

        public HourlyWeatherViewModel(List<HourlyForecast> hourlyForecast)
        {
            HourlyForecast = hourlyForecast;
        }
    }
}
