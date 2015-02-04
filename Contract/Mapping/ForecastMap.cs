using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.Entities;
using FluentNHibernate.Mapping;

namespace Contract.Mapping
{
    class ForecastMap: ClassMap<Forecast>
    {
        public ForecastMap()
        {
            References(x => x.Id);
            Map(x => x.LastUpdate);
            Map(x => x.WeatherJson);
        }
    }
}
