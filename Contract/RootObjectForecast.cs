using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{

    public class CoordForecast
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class CityForecast
    {
        public int id { get; set; }
        public string name { get; set; }
        public CoordForecast coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }

    public class TempForecast
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class WeatherForecast
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class ListForecast
    {
        public int dt { get; set; }
        public TempForecast temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public List<WeatherForecast> weather { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public int clouds { get; set; }
        public int? rain { get; set; }
        public double? snow { get; set; }
    }

    public class RootObjectForecast
    {
        public string cod { get; set; }
        public double message { get; set; }
        public CityForecast city { get; set; }
        public int cnt { get; set; }
        public List<ListForecast> list { get; set; }
    }
}
