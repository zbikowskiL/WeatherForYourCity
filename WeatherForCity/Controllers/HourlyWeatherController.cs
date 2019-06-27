using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherForCity.Models;
using WeatherForCity.Models.Interfaces;
using WeatherForCity.Models.ViewModels;

namespace WeatherForCity.Controllers
{
    [Route("api/[controller]")]
    public class HourlyWeatherController : Controller
    {
        private readonly IWeatherClient _weatherClient;

        public HourlyWeatherController(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult City()
        {
            return View("City");
        }

        [HttpPost]
        public async Task<IActionResult> City(string city)
        {
            var ressponse = await _weatherClient.HourlyWeatherForCity(city);
            HourlyWeather hourlyWeather = JsonConvert.DeserializeObject<HourlyWeather>(ressponse);

            MemoryStream ms = new MemoryStream();

            var lista = hourlyWeather.HourlyForecastList;
            var lista2 = lista.SelectMany(x => x.Weather).ToList();

            var image = lista2.Select(x => x.Icon).FirstOrDefault();
          
            HourlyWeatherViewModel hourlyWeatherViewModel = new HourlyWeatherViewModel(lista);

            return View("DetailsHourlyWeather", hourlyWeatherViewModel);
        }
    }
}