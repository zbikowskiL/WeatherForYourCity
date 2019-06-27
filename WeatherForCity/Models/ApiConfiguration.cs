using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public class ApiConfiguration
    {
        private const string ApiKey = "";
        private const string Url = "https://api.openweathermap.org";
        private const string Parameter = "units=metric";
        private const string CityParameter = "/data/2.5/weather?q=";
        private const string HourlyParameter = "/data/2.5//forecast/hourly?q=";
        private const string XmlParameter = "mode=xml";
        private const string Forecats5DaysEvery3hourParameter = "/data/2.5/forecast?q=";

        public ApiConfiguration()
        {
           
        }

        public string ConnectionStringForCity(string cityName)
        {
            return $"{CityParameter}{cityName}&{ApiKey}&{Parameter}";
        }

        public string ConnectionString5dayEvery3hour(string cityName)
        {
            return $"{Forecats5DaysEvery3hourParameter}{cityName}&{ApiKey}&{Parameter}";
        }

        public string ConnectionString5dayEvery3HourXML(string cityName)
        {
            return $"{Url}{Forecats5DaysEvery3hourParameter}{cityName}&{XmlParameter}&{ApiKey}&{Parameter}";
        }

        public string ConnectionStringForHourlyWeatherForCity(string cityName)
        {
            return $"{HourlyParameter}{cityName}&{ApiKey}&{Parameter}";
        }

        public string BaseUrl()
        {
            return Url;
        }
    }
}
