using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForCity.Models.Interfaces;

namespace WeatherForCity.Models.Services
{
    public class WeatherClient : IWeatherClient
    {
        ApiConfiguration apiConfiguration = new ApiConfiguration();
        private readonly HttpClient _httpClient;


        public WeatherClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(apiConfiguration.BaseUrl());
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient = httpClient;
        }

        public async Task<string> WeatherForCity(string city)
        {
            string result = "";
            try
            {
                result = await _httpClient.GetStringAsync(apiConfiguration.ConnectionStringForCity(city));

                if (string.IsNullOrEmpty(result))
                {
                    throw new Exception("Error during execution WeatherForCity() in WeatherClient");
                }
            }
            catch (HttpRequestException ex)
            {
                ex.ToString();
            }
           
            return result;
        }

        public async Task<string> Forecast5DaysEver3hour(string city)
        {
            string result = "";

            try
            {
                result = await _httpClient.GetStringAsync(apiConfiguration.ConnectionString5dayEvery3hour(city));

                if (string.IsNullOrEmpty(result))
                {
                    throw new Exception("Error during execution Forecast5DaysEver3hour() in WeatherClient");
                }
            }
            catch (HttpRequestException ex)
            {
                ex.ToString();
            }
           
            return result;
        }

        public async Task<string> HourlyWeatherForCity(string city)
        {
            string result = "";

            try
            {
                result = await _httpClient.GetStringAsync(apiConfiguration.ConnectionStringForHourlyWeatherForCity(city));

                if (string.IsNullOrEmpty(result))
                {
                    throw new Exception("Error during execution HourlyWeatherForCity() in WeatherClient");
                }
            }
            catch (HttpRequestException ex)
            {
                ex.ToString();
            }
            
            return result;
        }

        public async Task<string> Forecast5daysEver3hours(string city)
        {
            string result = "";

            try
            {
                result = await _httpClient.GetStringAsync(apiConfiguration.ConnectionString5dayEvery3hour(city));

                if (string.IsNullOrEmpty(result))
                {
                    throw new Exception("Error during execution HourlyWeatherForCity() in WeatherClient");
                }
            }
            catch (HttpRequestException ex)
            {
                ex.ToString();
            }
            
            return result;
        }

        public async Task<Stream> Forecast5daysEver3hoursXML(string city)
        {
            System.IO.Stream stream = new System.IO.MemoryStream();
            try
            {
                string url = apiConfiguration.ConnectionString5dayEvery3HourXML(city);
                stream = _httpClient.GetStreamAsync(url).Result;

                if (stream == null)
                {
                    throw new Exception("Error during execution HourlyWeatherForCity() in WeatherClient");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
           
            return stream;
        }
    }
}
