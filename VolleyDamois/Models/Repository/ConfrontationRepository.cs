using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolleyDamois.Models.Repository.Interfaces;

namespace VolleyDamois.Models.Repository
{
    public class ConfrontationRepository : CRUDRepository<Confrontation>, IConfrontationRepository
    {
        public ConfrontationRepository(VolleyDbContext context) : base(context)
        {}

        public async Task<IDictionary<DateTime, IList<Confrontation>>> ByRounds(string searchedTeam)
        {
            IQueryable<Confrontation> confrontations = Context.Confrontations;
            if (!string.IsNullOrWhiteSpace(searchedTeam))
                confrontations = confrontations.Where(c => c.TeamA.Name == searchedTeam || c.TeamB.Name == searchedTeam);
            return confrontations.ToList().GroupBy(r => r.BeginTime).OrderBy(g => g.Key).ToDictionary(r => r.Key, r => (IList<Confrontation>)r.OrderBy(c => c.Terrain.Number).ToList());
        }

        public async Task EncodeSetsFor(int id, int setOneA, int setOneB, int setTwoA, int setTwoB)
        {
            var confrontation = await FindById(id);
            confrontation.SetOneA = setOneA > 0 ? setOneA : 0;
            confrontation.SetOneB = setOneB > 0 ? setOneB : 0;
            confrontation.SetTwoA = setTwoA > 0 ? setTwoA : 0;
            confrontation.SetTwoB = setTwoB > 0 ? setTwoB : 0;
        }

        public async Task<IDictionary<Category, IList<Confrontation>>> WithHighestLevelByCategory()
        {
            var highestLevel = Context.Confrontations.Max(c => c.Level.Order);
            return (await Context.Confrontations.Where(c => c.Level.Order == highestLevel).ToListAsync()).GroupBy(c => c.TeamA.Category).ToDictionary(g => g.Key, g => (IList<Confrontation>)g.ToList());
        }

        public async Task<int> HighestLevel() => !IsEmpty() ? await Context.Confrontations.MaxAsync(c => c.Level.Order) : 0;
    }
}
