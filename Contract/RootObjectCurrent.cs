using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class CoordCurrent
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class SysCurrent
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public object sunrise { get; set; }
        public object sunset { get; set; }
    }

    public class WeatherCurrent
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class MainCurrent
    {
        public double temp { get; set; }
        public double humidity { get; set; }
        public double pressure { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double? sea_level { get; set; }
        public double? grnd_level { get; set; }
    }

    public class WindCurrent
    {
        public double speed { get; set; }
        public double gust { get; set; }
        public double deg { get; set; }
    }

    public class SnowCurrent
    {
        public double snow3h { get; set; }
    }

    public class CloudsCurrent
    {
        public int all { get; set; }
    }

    public class RainCurrent
    {
        public int rain3h { get; set; }
    }

    public class CityCurrent
    {
        public CoordCurrent coord { get; set; }
        public SysCurrent sys { get; set; }
        public List<WeatherCurrent> weather { get; set; }
        public MainCurrent main { get; set; }
        public WindCurrent wind { get; set; }
        public SnowCurrent snow { get; set; }
        public CloudsCurrent clouds { get; set; }
        public int dt { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public RainCurrent rain { get; set; }
    }

    public class RootObjectCurrent
    {
        public int cnt { get; set; }
        public List<CityCurrent> list { get; set; }
    }
}
