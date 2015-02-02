using System;
using System.Runtime.Remoting.Messaging;

namespace Contract
{
    class CurrentWeather
    {

        public int CiyId { get; set; }

        public object Sunrise { get; set; }
        public object Sunset { get; set; }

        public string Weather { get; set; } // snow, rain, clouds ir t.t.

        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }

        public double WindSpeed { get; set; }
        public double WindDeg { get; set; }

        public double WindChill { get; private set; }

        public void CalculateWindChill()
        {
            WindChill = Math.Round(13.12 + (0.6215 * Temperature) - (11.37 * Math.Pow(WindSpeed, 0.16)) + (0.3965 * Temperature * Math.Pow(WindSpeed, 0.16)), 2);
        }
    }
}