using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Entities
{
    class Current
    {
        public virtual int Id { get; set; }
        public virtual DateTime? LastUpdate { get; set; }
        public virtual string WeatherJson { get; set; }
    }
}
