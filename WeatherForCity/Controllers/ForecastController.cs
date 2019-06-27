using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherForCity.Models;
using WeatherForCity.Models.Interfaces;
using WeatherForCity.Models.ViewModels;

namespace WeatherForCity.Controllers
{
    //[Route("api/[controller]")]
    public class ForecastController : Controller
    {
        private readonly IWeatherClient _weatherClient;

        public ForecastController(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> City(string city)
        {
            try
            {
                var response = await _weatherClient.WeatherForCity(city);
                OpenWeatherResponse weather = JsonConvert.DeserializeObject<OpenWeatherResponse>(response);

                CityViewModel cityViewModel = new CityViewModel(weather);
                return View("City", cityViewModel);
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting weather from OpenWeater: {httpRequestException.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CurentForecast(string cityName)
        {
            OpenWeatherResponse weather;
            CityViewModel cityViewModel;

            if (string.IsNullOrEmpty(cityName))
            {
                return RedirectToAction("CurentForecast");
            }

            var response = await _weatherClient.WeatherForCity(cityName);
            if (response == "")
            {
                return RedirectToAction("CurentForecast");   
            }
            else
            {
                weather = JsonConvert.DeserializeObject<OpenWeatherResponse>(response);
                cityViewModel = new CityViewModel(weather);
            }

            return View("City", cityViewModel);
        }

        [HttpGet]
        public IActionResult CurentForecast()
        {
            return View("CurentForecast");
        }
    }
}