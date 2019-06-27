using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForCity.Models
{
    public static class TranslateDescryptionWeather
    {
        public static readonly Dictionary<string, string> TranslateDescription = new Dictionary<string, string>
        {
            { "clear sky" , "czyste niebo" },
            { "few clouds" , "kilka chmur" },
            { "scattered clouds" , "rozproszone chmury" },
            { "broken clouds" , "połamane chmury" },
            { "shower rain" , "deszcz pod prysznicem" },
            { "rain" , "deszcz" },
            { "thunderstorm" , "burza" },
            { "snow" , "śnieg" },
            { "mist" , "zamglenie" },
            { "thunderstorm with light rain" , "burza z lekkim deszczem " },
            { "thunderstorm with rain" , "burza z piorunami i deszczem " },
            { "thunderstorm with heavy rain" , "burza z silnym deszczem " },
            { "light thunderstorm" , "lekka burza z piorunami" },
            { "heavy thunderstorm" , "ciężka burza z piorunami" },
            { "ragged thunderstorm" , "poszarpana burza z piorunami" },
            { "thunderstorm with light drizzle" , "burza z lekką mżawką " },
            { "thunderstorm with drizzle" , "burza z piorunami z mżawką" },
            { "thunderstorm with heavy drizzle" , "burza z ciężką mżawką " },
            { "light intensity drizzle" , "mżawka o natężeniu światła" },
            { "drizzle" , "mżawka" },
            { "heavy intensity drizzle" , "mżawka o dużej intensywności" },
            { "light intensity drizzle rain" , "natężenie światła mżawka deszcz deszczu" },
            { "drizzle rain" , "deszcz mżawki" },
            { "heavy intensity drizzle rain" , "intensywna mżawka deszczowa o dużej intensywności" },
            { "shower rain and drizzle" , "deszcz i mżawka pod prysznicem" },
            { "heavy shower rain and drizzle" , "ulewny deszcz i mżawka " },
            { "shower drizzle" , "mżawka natryskowa" },
            { "light rain" , "lekki deszcz" },
            { "moderate rain" , "umiarkowany deszcz" },
            { "heavy intensity rain" , "intensywne opady deszczu" },
            { "very heavy rain" , "bardzo ulewny deszcz" },
            { "extreme rain" , "ekstremalny deszcz" },
            { "freezing rain" , "mroźny deszcz" },
            { "light intensity shower rain" , "natężenie światła deszczu natryskowego" },
            { "heavy intensity shower rain" , "intensywne opady deszczu pod prysznicem" },
            { "ragged shower rain" , "poszarpany deszcz pod prysznicem" },
            { "light snow" , "lekki śnieg" },
            { "Heavy snow" , "ciężki śnieg" },
            { "Sleet" , "sleet" },
            { "Light shower sleet" , "lekka tuleja prysznicowa" },
            { "Shower sleet" , "ścienka prysznicowa" },
            { "Light rain and snow" , "lekki deszcz i śnieg" },
            { "Rain and snow" , "deszcz i śnieg" },
            { "Light shower snow" , "lekki śnieg pod prysznic" },
            { "Shower snow" , "prysznicowy śnieg" },
            { "Heavy shower snow" , "ciężki śnieg pod prysznicem" },
            { "Smoke" , "dym" },
            { "Haze" , "haze" },
            { "sand/ dust whirls" , "wiry piasku/kurzu" },
            { "fog" , "mgła" },
            { "sand" , "piasek" },
            { "dust" , "pył" },
            { "volcanic ash" , "popiół wulkaniczny" },
            { "squalls" , "gąszcze" },
            { "tornado" , "tornado" },
            { "few clouds: 11-25%" , "kilka chmur: 11-25% " },
            { "scattered clouds: 25-50%" , "rozproszone chmury: 25-50% " },
            { "broken clouds: 51-84%" , "połamane chmury: 51-84% " },
            { "overcast clouds: 85-100%" , "chmury zachmurzone: 85-100% " },
            { "overcast clouds", "chmury zachmurzone" }

        };
    }
}
