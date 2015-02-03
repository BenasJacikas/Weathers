using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Contract
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection source = new SQLiteConnection("Data Source = Weather.sqlite");
            source.Open();

            using (SQLiteConnection destination = new SQLiteConnection("Data Source=:memory:"))
            {
                destination.Open();

                // copy db file to memory
                source.BackupDatabase(destination, "main", "main", -1, null, 0);
                source.Close();

                //--------------------
                
                //WeatherDB.InsertCurrent(destination, );
                //WeatherDB.SelectAllCurrent(destination);
                //WeatherDB.GetCurrentWeather(destination, 2988507);
                //WeatherDB.InsertCity(destination, 524901);
                //WeatherDB.SelectAllCities(destination);
                /*var list = GetCurrent("2988507");
                foreach (var item in list)
                {
                    string weatherjson = JsonConvert.SerializeObject(item);
                    WeatherDB.InsertCurrent(destination, item.CiyId, weatherjson);
                }*/

                WeatherDB.CreateDatabase();

                //--------------------
                // save memory db to file
                source = new SQLiteConnection("Data Source= Weather.sqlite");
                source.Open();
                destination.BackupDatabase(source, "main", "main", -1, null, 0);
                source.Close();
            }
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
