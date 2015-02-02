using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, CurrentWeather> currentWeathers = new Dictionary<int, CurrentWeather>();
            var data = GetCurrent("456172");
            foreach (var item in data)
            {
                currentWeathers.Add(item.CiyId, item);
            }

            foreach (var item in currentWeathers)
            {
                Console.WriteLine(item.Key + item.Value.Temperature);
            }
            Console.Read();
        }

        static object GetForecast(object cityData)
        {
            return null;
        }

        static List<CurrentWeather> GetCurrent(string cityData)
        {
            return OpenWeatherMapCurrent.GetCurrentWeatherJson(cityData);
        }
    }
}
