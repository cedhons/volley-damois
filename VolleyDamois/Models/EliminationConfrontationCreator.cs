using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using VolleyDamois.Models.Interfaces;
using VolleyDamois.Models.Repository.Interfaces;

namespace VolleyDamois.Models
{
    public class EliminationConfrontationCreator : IEliminationConfrontationCreator
    {
        private IRoundDateTimes _rounds;

        public EliminationConfrontationCreator(IRoundDateTimes rounds)
        {
            _rounds = rounds;
        }

        public IList<Confrontation> Create(IList<Confrontation> confrontations, IList<Terrain> terrains)
        {
            var result = new List<Confrontation>();
            var lastConfrontationTime = confrontations.Max(c => c.BeginTime);

            var level = new Level { Order = confrontations.First().Level.Order + 1, Name = GetRoundName(confrontations.Count / 2) };

            for (int i = 0; i < confrontations.Count / 2; i++)
            {
                var confrontationA = confrontations[i];
                var confrontationB = confrontations[confrontations.Count - 1 - i];
                result.Add(new Confrontation
                {
                    TeamA = confrontationA.Winner,
                    TeamB = confrontationB.Winner,
                    TeamReferee = confrontationA.Loser,
                    Terrain = terrains[i % terrains.Count],
                    BeginTime = _rounds.DateTimesAfter(lastConfrontationTime)[i / terrains.Count],
                    Level = level
                });
            }

            return result;
        }

        private string GetRoundName(int nbConfrontations)
        {
            switch (nbConfrontations)
            {
                case 1:
                    return "finale";
                case 2:
                    return "demi finale";
                default:
                    return $"1/{nbConfrontations} de finale";
            }
        }
    }
}
