using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyDamois.Models.Interfaces
{
    public interface IRoundDateTimes
    {
        IList<DateTime> DateTimes(DateTime initialDay);
        IList<DateTime> DateTimesAfter(DateTime dateTime);
    }
}
