using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Contract
{
    class OpenWeatherMapForecast
    {
        private const string Apikey = "2026764a2ab3c5cdf8d7d57593c56c05";
        private const string Units = "metric";
        private const int Days = 3;

        public static RootObjectForecast GetForecastWeatherJson(string city)
        {
            var url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?id={0}&units={1}&cnt={2}&APPID={3}", city, Units, Days, Apikey);
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }
            Console.WriteLine(json);
            RootObjectForecast forecast = JsonConvert.DeserializeObject<RootObjectForecast>(json);
            return forecast;
        }
    }
}
