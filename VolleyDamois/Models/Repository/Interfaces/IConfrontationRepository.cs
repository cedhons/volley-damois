using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolleyDamois.Models.Enum;

namespace VolleyDamois.Models.Repository.Interfaces
{
    public interface IConfrontationRepository : ICRUDRepository<Confrontation>
    {
        Task<IDictionary<DateTime, IList<Confrontation>>> ByRounds(string searchedTeam);
        Task EncodeSetsFor(int id, int setOneA, int setOneB, int setTwoA, int setTwoB);
        Task<IDictionary<Category, IList<Confrontation>>> WithHighestLevelByCategory();
        Task<int> HighestLevel();
    }
}
