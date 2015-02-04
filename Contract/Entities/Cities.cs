using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Entities
{
    class Cities
    {
        public virtual int Id { get; set; }
        public virtual int Counter { get; set; }
        public virtual DateTime LastRequest { get; set; }
        public virtual Current Current { get; set; }
        public virtual Forecast Forecast { get; set; }
    }
}
