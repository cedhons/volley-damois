using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using VolleyDamois.Models.Interfaces;

namespace VolleyDamois.Models
{
    public class RoundDateTimes : IRoundDateTimes
    {

        public IList<DateTime> DateTimes(DateTime initialDay)
        {
            var rounds = new List<DateTime>();
            //Before 12h30
            for (int i = 0; i <= 3; i++)
                for (int j = 0; j <= 1 && (j < 1 || i < 3); j++)
                    rounds.Add(new DateTime(initialDay.Year, initialDay.Month, initialDay.Day, 9 + i, j * 30, 0));
            //After 13h30
            for (int i = 0; i <= 10; i++)
            {
                if (i > 0)
                    rounds.Add(new DateTime(initialDay.Year, initialDay.Month, initialDay.Day, 13 + i, 0, 0));
                rounds.Add(new DateTime(initialDay.Year, initialDay.Month, initialDay.Day, 13 + i, 30, 0));
            }

            return rounds;
        }

        public IList<DateTime> DateTimesAfter(DateTime dateTime)
        {
            return DateTimes(dateTime).Where(d => d.Hour > dateTime.Hour || d.Hour == dateTime.Hour && d.Minute > dateTime.Minute).OrderBy(d => d).ToList();
        }
    }
}
