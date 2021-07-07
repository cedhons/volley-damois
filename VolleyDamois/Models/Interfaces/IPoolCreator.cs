using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyDamois.Models.Interfaces
{
    public interface IPoolCreator
    {
        IList<Pool> Create(IList<Team> teams);
    }
}
