using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyDamois.Models.Interfaces
{
    public interface IPoolBasedConfrontationCreator
    {
        ConfrontationCreatorType CreatorType { get; }
        IList<Confrontation> Create(IList<Pool> pools, IList<Terrain> terrains);
    }

    public enum ConfrontationCreatorType
    {
        Pool,
        Elimination
    }
}
