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

namespace WeatherForCity.Models
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IWeatherClient _weatherClient;
 
        public WeatherController(IWeatherClient weatherClient)
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

        public IActionResult Index()
        {
            return View("Index");           
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetImage()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"http://openweathermap.org/img/w/");

                var response = await client.GetAsync("10d.png");
                byte[] myBytes = await response.Content.ReadAsByteArrayAsync();
                string convertedFromString = Convert.ToBase64String(myBytes, 0, myBytes.Length);

                response.EnsureSuccessStatusCode();
                ViewBag.Base64String = "data:image/png;base64," + convertedFromString;

                return View();
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DailyForecast(string cityName)
        {
            var response = await _weatherClient.WeatherForCity(cityName);
            OpenWeatherResponse weather = JsonConvert.DeserializeObject<OpenWeatherResponse>(response);

            CityViewModel cityViewModel = new CityViewModel(weather);
            return View("City", cityViewModel);
        }

        [HttpGet("[action]")]
        public IActionResult DailyForecast()
        {
            return View("DailyForecast");
        }
    }
}