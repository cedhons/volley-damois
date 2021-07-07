using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyDamois.Models
{
    public class Pool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Team> Teams { get; set; }
    }
}
