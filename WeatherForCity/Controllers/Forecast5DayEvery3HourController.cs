using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherForCity.Models;
using WeatherForCity.Models.Interfaces;
using WeatherForCity.Models.ViewModels;
using WeatherForCity.Models.XMLModel;

namespace WeatherForCity.Controllers
{
    public class Forecast5DayEvery3HourController : Controller
    {
        private readonly IWeatherClient _weatherClient;

        public Forecast5DayEvery3HourController(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        [HttpPost]
        public async Task<IActionResult> Forecast5DayEvery3Hour(string cityName)
        {
            try
            {
                var response = await _weatherClient.Forecast5daysEver3hours(cityName);
                Response5DayEvery3Hour deserializeResponse = JsonConvert.DeserializeObject<Response5DayEvery3Hour>(response);

                var list = deserializeResponse.Forecast5DayEvery3HourList;

                Forecast5DayEvery3HourViewModel viewModel = new Forecast5DayEvery3HourViewModel(list, cityName);
                if (TimeAndTemp.TimeAndTempList.Count > 0)
                    TimeAndTemp.TimeAndTempList.Clear();

                foreach (var item in list)
                {
                    int indexOf = item.DateEvery3Hour.IndexOf(" ");
                    int stringLength = item.DateEvery3Hour.Length;

                    TimeAndTemp timeAndTemp = new TimeAndTemp();
                    timeAndTemp.Time = item.DateEvery3Hour.Substring(indexOf + 1, stringLength - indexOf - 4);
                    timeAndTemp.Temperature = item.Main.Temp;

                    TimeAndTemp.TimeAndTempList.Add(timeAndTemp);
                }

                return View("Forecast5DayEvery3HourDetails", viewModel);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting weather from OpenWeater: {httpRequestException.Message}");
            }
        }

        [HttpGet]
        public IActionResult Forecast5DayEvery3Hour()
        {
            return View("Forecast5DayEvery3Hour");
        }

        //[Produces("application/json")]
        public IActionResult DataForChart(string cityName)
        {
            try
            {
                var data = TimeAndTemp.TimeAndTempList.Take(6);

                return Ok(data);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting weather from OpenWeater: {httpRequestException.Message}");
            }
        }

        public IActionResult DataForChartXML(string cityName)
        {
            try
            {
                var data = TimeTempPrecipitation.TimeTempPrecipitationList.Take(9);

                return Ok(data);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting weather from OpenWeater: {httpRequestException.Message}");
            }
        }

        [HttpGet]
        public IActionResult Forecast5DayEvery3HourXML()
        {
            return View("Forecast5DayEvery3HourXML");
        }

        [HttpPost]
        public async Task<IActionResult> Forecast5DayEvery3HourXML(string cityName)
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(WeatherData));
                Stream response = await _weatherClient.Forecast5daysEver3hoursXML(cityName);
                object dataFromXML;

                if (response.CanSeek)
                {
                    return RedirectToAction("Forecast5DayEvery3HourXML");
                }

                using (StreamReader reader = new StreamReader(response))
                {
                    dataFromXML = deserializer.Deserialize(reader);
                }
                
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(WeatherData));
                WeatherData weatherData = (WeatherData)dataFromXML;

                Forecast5DayEvery3HourXMLViewModel viewModel = new Forecast5DayEvery3HourXMLViewModel(weatherData);

                return View("Forecast5DayEvery3HourDetailsXML", viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting weather from OpenWeater: {ex.Message}");
            }
        }

    }
}