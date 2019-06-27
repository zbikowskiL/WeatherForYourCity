using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models.Interfaces
{
    public interface IWeatherClient
    {
        Task<string> WeatherForCity(string city);
        Task<string> HourlyWeatherForCity(string city);
        Task<string> Forecast5daysEver3hours(string city);
        Task<Stream> Forecast5daysEver3hoursXML(string city);
    }
}
