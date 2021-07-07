using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using VolleyDamois.Models.Interfaces;
using VolleyDamois.Models.Validators;

namespace VolleyDamois.Models
{
    public class PoolCreator : IPoolCreator
    {
        public IList<Pool> Create(IList<Team> teams)
        {
            if (teams.Count % PoolRules.MAX_TEAMS == 0) 
                return GroupTeamsInPools(teams, teams.Count / PoolRules.MAX_TEAMS);

            return CreateSmallPools(teams);
        }

        private IList<Pool> CreateSmallPools(IList<Team> teams)
        {
            for (int i = PoolRules.MAX_TEAMS - 1; i >= PoolRules.MIN_TEAMS; i--)
            {
                int remainingTeams = teams.Count % i;
                int nbPools = teams.Count / i;
                if(remainingTeams <= nbPools)
                    return GroupTeamsInPools(teams, nbPools);
            }

            return null;
        }

        private IList<Pool> GroupTeamsInPools(IList<Team> teams, int nbPools)
        {
            var pools = new List<Pool>();

            for(int i = 0; i < nbPools; i++)
                pools.Add(new Pool { Name = $"Poule {i + 1}", Teams = new List<Team>() });

            for (int i = 0; i < teams.Count; i++)
                pools[i % nbPools].Teams.Add(teams[i]);

            return pools;
        }
    }
}
