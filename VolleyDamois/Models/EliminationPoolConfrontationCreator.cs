using System;
using System.Collections.Generic;
using System.Linq;
using VolleyDamois.Models.Interfaces;

namespace VolleyDamois.Models
{
    public class EliminationPoolConfrontationCreator : IPoolBasedConfrontationCreator
    {
        private readonly IList<DateTime> _rounds;

        public EliminationPoolConfrontationCreator(IRoundDateTimes roundDateTimes)
        {
            _rounds = roundDateTimes.DateTimes(new DateTime(2020, 7, 2));
        }

        public ConfrontationCreatorType CreatorType => ConfrontationCreatorType.Elimination;

        public IList<Confrontation> Create(IList<Pool> pools, IList<Terrain> terrains)
        {
            if (pools.Count % 2 == 0)
                return EvenPoolsConfrontations(pools, terrains);
            return new List<Confrontation>();
        }

        private IList<Confrontation> EvenPoolsConfrontations(IList<Pool> pools, IList<Terrain> terrains)
        {
            var confrontations = new List<Confrontation>();
            var orderedTeams = new List<IList<Team>>();
            foreach (var pool in pools)
                orderedTeams.Add(pool.Teams.OrderByDescending(t => t.Points).ThenByDescending(t => t.PointsFor).ThenBy(t => t.PointsAgainst).ToList());

            var level = new Level { Order = 1, Name = $"1/{ pools.Count * 2 } de finale" };
            for (int i = 0; i < orderedTeams.Count; i += 2)
            {
                for (int j = 0; j < 4; j++)
                {
                    confrontations.Add(new Confrontation
                    {
                        TeamA = orderedTeams[i][j],
                        TeamB = orderedTeams[i + 1][3 - j],
                        TeamReferee = FindTeamReferee(orderedTeams, i, j),
                        Terrain = terrains[j],
                        BeginTime = _rounds[i],
                        Level = level
                    });
                }
            }
            return confrontations;
        }

        private Team FindTeamReferee(List<IList<Team>> orderedTeams, int currentTeams, int currentConfrontation)
        {
            for (int i = 0; i < orderedTeams.Count; i++)
            {
                if (currentTeams != i && currentTeams + 1 != i)
                    return orderedTeams[i][currentConfrontation];
                if (orderedTeams[i].Count > currentConfrontation + 4)
                    return orderedTeams[i][currentConfrontation + 4];
            }
            return null;
        }
    }
}
