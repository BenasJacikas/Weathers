using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.Entities;
using FluentNHibernate.Mapping;

namespace Contract.Mapping
{
    class CitiesMap : ClassMap<Cities>
    {
        public CitiesMap()
        {
            Id(x => x.Id);
            Map(x => x.Counter);
            Map(x => x.LastRequest);
            HasOne(x => x.Counter);
            HasOne(x => x.Forecast);
        }
    }
}
