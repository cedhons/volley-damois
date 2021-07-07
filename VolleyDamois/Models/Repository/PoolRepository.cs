using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolleyDamois.Models.Repository.Interfaces;

namespace VolleyDamois.Models.Repository
{
    public class PoolRepository : CRUDRepository<Pool>, IPoolRepository
    {
        public PoolRepository(VolleyDbContext context) : base(context)
        {}

        public async Task<IDictionary<Category, IList<Pool>>> ByCategory()
        {
            /*
            var result = new Dictionary<Category, IList<Pool>>();
            var pools = await All();
            foreach (var pool in pools)
            {
                var firstTeam = pool.Teams.First();
                if (!result.ContainsKey(firstTeam.Category))
                    result[firstTeam.Category] = new List<Pool>();
                result[firstTeam.Category].Add(pool);
            }
            */
            return (await All()).GroupBy(p => p.Teams.First().Category).ToDictionary(g => g.Key, g => (IList<Pool>)g.ToList());
        }
    }
}
