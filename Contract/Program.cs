using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.Entities;
using Contract.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Newtonsoft.Json;
using NHibernate;

namespace Contract
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionFactory = CreateSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    var cities = session.CreateCriteria(typeof (Cities)).List<Cities>();
                    foreach (var city in cities)
                    {
                        Console.WriteLine(city.Id);
                    }
                }
            }
            Console.Read();
        }



        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure().
                Database(SQLiteConfiguration.Standard.UsingFile("Weather.sqlite")).
                Mappings(m => m.FluentMappings.AddFromAssemblyOf<CitiesMap>()).
                BuildSessionFactory();
        } 

        /*static List<CurrentWeather> GetCurrent(string cityData)
        {
            return (List<CurrentWeather>) Retry.DoFirstLevel(() => OpenWeatherMapCurrent.GetCurrentWeatherJson(cityData), TimeSpan.FromSeconds(1), cityData);
        }*/
    }
}
/*
            SQLiteConnection source = new SQLiteConnection("Data Source= Weather.sqlite");
            source.Open();

            using (SQLiteConnection destination = new SQLiteConnection(
              "Data Source=:memory:"))
            {
                destination.Open();

                // copy db file to memory
                source.BackupDatabase(destination, "main", "main", -1, null, 0);
                source.Close();

                // insert, select ,...        
                WeatherDB.SelectAllCities(destination);


                source = new SQLiteConnection("Data Source= Weather.sqlite");
                source.Open();

                // save memory db to file
                destination.BackupDatabase(source, "main", "main", -1, null, 0);
                source.Close();
            }
*/