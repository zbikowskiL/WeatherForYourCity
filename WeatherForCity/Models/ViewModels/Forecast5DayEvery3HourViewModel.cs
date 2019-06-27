using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models.ViewModels
{
    public class Forecast5DayEvery3HourViewModel
    {
        public string CityName { get; set; }

        public List<string> DistinctDates { get; set; }

        public List<Weather5DayEvery3Hour> Weather5DayEvery3HoursList { get; set; }

        private List<Forecast5DayEvery3Hour> Forecast5DayEvery3HourList { get; set; }
        
        public Forecast5DayEvery3HourViewModel()
        {

        }

        public Forecast5DayEvery3HourViewModel(List<Forecast5DayEvery3Hour> response5DayEvery3Hour, string cityName)
        {
            Forecast5DayEvery3HourList = response5DayEvery3Hour;
            Weather5DayEvery3HoursList = SetValueForWeather5DayEvery3Hours();
            DistinctDates = GetDistinctDate();
            CityName = cityName;
        }

        private List<string> GetDistinctDate()
        {
            DistinctDates = new List<string>();

            foreach (var item in Forecast5DayEvery3HourList)
            {
                int indexOf = item.DateEvery3Hour.IndexOf(" ");
                string stringDate = item.DateEvery3Hour.Substring(0, indexOf);

                if (!DistinctDates.Contains(stringDate))
                {
                    DistinctDates.Add(stringDate);
                }
            }
            return DistinctDates;
        }

        private List<Weather5DayEvery3Hour> SetValueForWeather5DayEvery3Hours()
        {
            List<Weather5DayEvery3Hour> Weather5DayEvery3HoursList = new List<Weather5DayEvery3Hour>();
            Weather5DayEvery3Hour weather5DayEvery3Hour;

            foreach (var item in Forecast5DayEvery3HourList)
            {
                int indexOf = item.DateEvery3Hour.IndexOf(" ");
                int stringLength = item.DateEvery3Hour.Length;

                weather5DayEvery3Hour = new Weather5DayEvery3Hour()
                {
                    Date = item.DateEvery3Hour.Substring(0, indexOf),
                    Hour = item.DateEvery3Hour.Substring(indexOf + 1, stringLength - indexOf - 4),
                    Temperature = item.Main.Temp,
                    CloudsPrecent = item.Clouds.CloudsPrecent,
                    Humidity = item.Main.Humidity,
                    Pressure = item.Main.Pressure,
                    WindSpeed = item.Wind.Speed,
                    Description = TranslateDescryptionWeather.TranslateDescription.ContainsKey(item.Weather.Select(x => x.Description).FirstOrDefault()) ? TranslateDescryptionWeather.TranslateDescription[item.Weather.Select(x => x.Description).FirstOrDefault()] : "brak opisu",
                    IconName = item.Weather.Select(x => x.Icon).FirstOrDefault() + ".png"
                };

                Weather5DayEvery3HoursList.Add(weather5DayEvery3Hour);
            }

            return Weather5DayEvery3HoursList;
        }


    }
}
