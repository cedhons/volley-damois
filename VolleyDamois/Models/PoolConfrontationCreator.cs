using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using VolleyDamois.Models.Interfaces;

namespace VolleyDamois.Models
{
    public class PoolConfrontationCreator : IPoolBasedConfrontationCreator
    {
        private readonly IList<DateTime> _rounds;

        public PoolConfrontationCreator(IRoundDateTimes roundDateTimes)
        {
            _rounds = roundDateTimes.DateTimes(new DateTime(2020, 7, 1));
        }

        public ConfrontationCreatorType CreatorType => ConfrontationCreatorType.Pool;

        public IList<Confrontation> Create(IList<Pool> pools, IList<Terrain> terrains)
        {
            var confrontations = new List<Confrontation>();
            int indexNewDateTime = 0;
            for (var i = 0; i < pools.Count; i++)
            {
                var pool = pools[i];
                var teamsCopy = pool.Teams.ToArray();
                var otherPools = pools.Where(p => p.Id != pool.Id).SelectMany(p => p.Teams).ToList();
                if (teamsCopy.Length % 2 == 0)
                    EvenRoundRobin(otherPools, terrains, teamsCopy, confrontations, indexNewDateTime);
                else
                    OddRoundRobin(otherPools, terrains, teamsCopy, confrontations, indexNewDateTime);
                indexNewDateTime = _rounds.IndexOf(confrontations.Last().BeginTime) + 1;
            }

            return confrontations;
        }

        private void EvenRoundRobin(IList<Team> otherTeams, IList<Terrain> terrains, Team[] teams, List<Confrontation> confrontations, int indexNewDateTime)
        {
            for (int j = 0; j < teams.Length - 1; j++)
            {
                var level = new Level { Name = $"Manche {indexNewDateTime + j + 1}", Order = 0 };
                RightRotate(teams);
                Permute(teams, 0, 1);
                for (int k = 0; k < teams.Length / 2; k++)
                {
                    confrontations.Add(new Confrontation
                    {
                        TeamA = teams[k],
                        TeamB = teams[teams.Length - 1 - k],
                        TeamReferee = otherTeams[(j * teams.Length / 2 + k) % otherTeams.Count],
                        Terrain = terrains[k],
                        BeginTime = _rounds[indexNewDateTime + j],
                        Level = level
                    });
                }
            }
        }        
        
        private void OddRoundRobin(IList<Team> otherTeams, IList<Terrain> terrains, Team[] teams, List<Confrontation> confrontations, int indexNewDateTime)
        {
            for (int j = 0; j < teams.Length; j++)
            {
                var level = new Level { Name = $"Manche {indexNewDateTime + j + 1}", Order = 0 };
                RightRotate(teams);
                for (int k = 0; k < teams.Length / 2; k++)
                {
                    confrontations.Add(new Confrontation
                    {
                        TeamA = teams[k],
                        TeamB = teams[teams.Length - 2 - k],
                        TeamReferee = otherTeams[(j * teams.Length / 2 + k) % otherTeams.Count],
                        Terrain = terrains[k],
                        BeginTime = _rounds[indexNewDateTime + j],
                        Level = level
                    });
                }
            }
        }

        private void Permute(Team[] teams, int i, int j)
        {
            var tmp = teams[i];
            teams[i] = teams[j];
            teams[j] = tmp;
        }

        private void RightRotate(Team[] teams)
        {
            var tmp = teams[teams.Length - 1];
            for (int i = teams.Length - 1; i > 0; i--)
                teams[i] = teams[i - 1];
            teams[0] = tmp;
        }
    }
}
