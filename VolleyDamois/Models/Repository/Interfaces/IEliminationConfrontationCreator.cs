using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyDamois.Models.Repository.Interfaces
{
    public interface IEliminationConfrontationCreator
    {
        IList<Confrontation> Create(IList<Confrontation> confrontations, IList<Terrain> terrains);
    }
}
