using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForCity.Models.XMLModel;

namespace WeatherForCity.Models.ViewModels
{
    public class Forecast5DayEvery3HourXMLViewModel
    {
        public string CityName { get; set; }

        public List<string> DistinctDates { get; set; }

        public List<Weather5DayEvery3Hour> Weather5DayEvery3HoursList { get; set; }

        private List<Forecast5DayEvery3Hour> Forecast5DayEvery3HourList { get; set; }

        private WeatherData WeatherData { get; set; }

        public Forecast5DayEvery3HourXMLViewModel()
        {

        }

        public Forecast5DayEvery3HourXMLViewModel(WeatherData weatherdata)
        {
            WeatherData = weatherdata;
            Weather5DayEvery3HoursList = SetValueForWeather5DayEvery3Hours();
            DistinctDates = GetDistinctDate();
            CityName = weatherdata.Location.CityName;
        }

        private List<string> GetDistinctDate()
        {
            DistinctDates = new List<string>();

            foreach (var item in WeatherData.Forecast.Time)
            {
                int indexOf = item.From.IndexOf("T");
                string stringDate = item.From.Substring(0, indexOf);

                if (!DistinctDates.Contains(stringDate))
                {
                    DistinctDates.Add(stringDate);
                }
            }
            return DistinctDates;
        }

        private void GetDistinctDateVoid()
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
        }

        private List<Weather5DayEvery3Hour> SetValueForWeather5DayEvery3Hours()
        {
            List<Weather5DayEvery3Hour> Weather5DayEvery3HoursList = new List<Weather5DayEvery3Hour>();
            Weather5DayEvery3Hour weather5DayEvery3Hour;
            TimeTempPrecipitation timeTempPrecipitation;

            if (TimeTempPrecipitation.TimeTempPrecipitationList.Count != 0)
                TimeTempPrecipitation.TimeTempPrecipitationList.Clear();

            foreach (var item in WeatherData.Forecast.Time)
            {
                int indexOf = item.From.IndexOf("T");
                int stringLength = item.From.Length;
                int cloudsPrecent;
                double temp, windSpeed, pressure, precipitation;
                long humidity;
                timeTempPrecipitation = new TimeTempPrecipitation();
                weather5DayEvery3Hour = new Weather5DayEvery3Hour();

                weather5DayEvery3Hour.Date = item.From.Substring(0, indexOf);
                weather5DayEvery3Hour.Hour = item.From.Substring(indexOf + 1, stringLength - indexOf - 4);
                timeTempPrecipitation.Time = DateTime.Parse(item.From.Replace('T', ' ')).ToString("dd-MM HH:mm");

                if (double.TryParse((item.Temperature.Value.Replace('.', ',')), out temp))
                {
                    weather5DayEvery3Hour.Temperature = temp;
                    timeTempPrecipitation.Temperature = (int)temp;
                    timeTempPrecipitation.TemperatureDescryption = ((int)temp).ToString();
                }

                if (int.TryParse((item.Clouds.All.Replace('.', ',')), out cloudsPrecent))
                    weather5DayEvery3Hour.CloudsPrecent = cloudsPrecent;

                if (long.TryParse((item.Humidity.Value.Replace('.', ',')), out humidity))
                    weather5DayEvery3Hour.Humidity = humidity;

                if (double.TryParse((item.Pressure.Value.Replace('.', ',')), out pressure))
                    weather5DayEvery3Hour.Pressure = (long)pressure;

                if (double.TryParse((item.WindSpeed.Mps.Replace('.', ',')), out windSpeed))
                    weather5DayEvery3Hour.WindSpeed = Math.Round(windSpeed, 2);

                if (item.Precipitation.Value == null)
                {
                    weather5DayEvery3Hour.Precipitation = 0.0;
                    timeTempPrecipitation.Precipitation = 0.0;
                    timeTempPrecipitation.PrecipitationDescryption = "0.00";
                }
                else
                {
                    if (double.TryParse((item.Precipitation.Value.Replace('.', ',')), out precipitation))
                    {
                        weather5DayEvery3Hour.Precipitation = Math.Round(precipitation, 2);
                        timeTempPrecipitation.Precipitation = Math.Round(precipitation, 2);
                        timeTempPrecipitation.PrecipitationDescryption = timeTempPrecipitation.Precipitation.ToString();
                    }

                }

                weather5DayEvery3Hour.WindDirection = TranslateDescryptionWind.TranslateDescription.ContainsKey(item.WindDirection.Name) ? TranslateDescryptionWind.TranslateDescription[item.WindDirection.Name] : "";
                weather5DayEvery3Hour.Description = TranslateDescryptionWeather.TranslateDescription.ContainsKey(item.Symbol.Name) ? TranslateDescryptionWeather.TranslateDescription[item.Symbol.Name] : "brak opisu";
                weather5DayEvery3Hour.IconName = item.Symbol.Var + ".png";

                Weather5DayEvery3HoursList.Add(weather5DayEvery3Hour);
                TimeTempPrecipitation.TimeTempPrecipitationList.Add(timeTempPrecipitation);
            }

            return Weather5DayEvery3HoursList;
        }
    }
}
