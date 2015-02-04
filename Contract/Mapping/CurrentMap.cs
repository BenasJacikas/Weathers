using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.Entities;
using FluentNHibernate.Mapping;

namespace Contract.Mapping
{
    class CurrentMap : ClassMap<Current>
    {
        public CurrentMap()
        {
            References(x => x.Id);
            Map(x => x.LastUpdate);
            Map(x => x.WeatherJson);
        }
    }
}
