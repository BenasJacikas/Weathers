using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Contract
{
    class OpenWeatherMapCurrent
    {
        private const string Apikey = "2026764a2ab3c5cdf8d7d57593c56c05";
        private const string Units = "metric";

        public static List<CurrentWeather> GetCurrentWeatherJson(string cities)
        {
            var url = string.Format("http://api.openweathermap.org/data/2.5/group?id={0}&units={1}&APPID={2}", cities, Units, Apikey);
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }
            RootObjectCurrent weather = JsonConvert.DeserializeObject<RootObjectCurrent>(json);
            return CurrentConverter(weather);
        }

        private static List<CurrentWeather> CurrentConverter(RootObjectCurrent current)
        {
            List<CurrentWeather> weatherDatas = new List<CurrentWeather>();

            foreach (var item in current.list)
            {
                CurrentWeather weatherData = new CurrentWeather();
                weatherData.CiyId = item.id;
                weatherData.Sunrise = item.sys.sunrise;
                weatherData.Sunset = item.sys.sunset;
                weatherData.Temperature = item.main.temp;
                weatherData.Humidity = item.main.humidity;
                weatherData.Pressure = item.main.pressure;
                weatherData.WindSpeed = item.wind.speed;
                weatherData.WindDeg = item.wind.deg;
                weatherData.Weather = item.weather[0].main;
                weatherData.CalculateWindChill();
                weatherDatas.Add(weatherData);
            }

            return weatherDatas;
        }
    }
}
