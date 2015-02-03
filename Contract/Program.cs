using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    class Program
    {
        static void Main(string[] args)
        {
            //SQLiteConnection connection = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;");
            var data2 = GetCurrent("593116");
            Console.WriteLine(data2[0].CiyId + " " + data2[0].Temperature + " " + data2[0].Weather);
            Console.Read();
        }

        static object GetForecast(object cityData)
        {
            return null;
        }

        static List<CurrentWeather> GetCurrent(string cityData)
        {
            return (List<CurrentWeather>) Retry.DoFirstLevel(() => OpenWeatherMapCurrent.GetCurrentWeatherJson(cityData), TimeSpan.FromSeconds(1), cityData);
        }
    }
}
