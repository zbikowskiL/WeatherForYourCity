using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models.ViewModels
{
    public class CityViewModel
    {
        [Display(Name = "Miasto")]
        public string CityName { get; set; }

        public string Country { get; set; }

        [Display(Name = "Temperatura")]
        public double Temperature { get; set; }

        [Display(Name = "Ciśnienie")]
        public long Pressure { get; set; }

        [Display(Name = "Wilgotność")]
        public long Humidity { get; set; }

        [Display(Name = "Temperatura minimalna")]
        public double TempMin { get; set; }

        [Display(Name = "Temperatura maksymalna")]
        public double TempMax { get; set; }

        [Display(Name = "Długość geograficzna")]
        public double Longitude { get; set; }

        [Display(Name = "Szerokość geograficzna")]
        public double Latitude { get; set; }

        [Display(Name = "Prędkość wiatru")]
        public string WindSpeed { get; set; }

        [Display(Name = "Zachmurzenie")]
        public string Cloudy { get; set; }

        [Display(Name = "Wschód słońca")]
        public TimeSpan Sunrise { get; set; }

        [Display(Name = "Zachód słońca")]
        public TimeSpan SunSet { get; set; }

        public string Icon { get; set; }

        public CityViewModel()
        {

        }

        public CityViewModel(OpenWeatherResponse openWeatherResponse)
        {
            CityName = openWeatherResponse.Name;
            Country = openWeatherResponse.CountrySunrise.Country;
            Temperature = openWeatherResponse.Main.Temp;
            Pressure = openWeatherResponse.Main.Pressure;
            Humidity = openWeatherResponse.Main.Humidity;
            TempMax = openWeatherResponse.Main.TempMax;
            TempMin = openWeatherResponse.Main.TempMin;
            Longitude = openWeatherResponse.GetGeoLocation.Longitude;
            Latitude = openWeatherResponse.GetGeoLocation.Latitude;
            WindSpeed = openWeatherResponse.Wind.Speed.ToString();
            Cloudy = TranslateDescryptionWeather.TranslateDescription.ContainsKey(openWeatherResponse.Weather.Select(x => x.Description).FirstOrDefault()) ? TranslateDescryptionWeather.TranslateDescription[openWeatherResponse.Weather.Select(x => x.Description).FirstOrDefault()] : "brak opisu";
            Icon = string.Format(openWeatherResponse.Weather.Select(x => x.Icon).FirstOrDefault() + ".png");
            Sunrise = UnixTimeStampToDateTime(openWeatherResponse.CountrySunrise.Sunrise);
            SunSet = UnixTimeStampToDateTime(openWeatherResponse.CountrySunrise.Sunset);
        }

        static TimeSpan UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.TimeOfDay;
        }
    }
}
