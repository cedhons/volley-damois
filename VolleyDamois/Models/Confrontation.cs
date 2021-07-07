using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyDamois.Models
{
    public class Confrontation
    {
        public int Id { get; set; }
        public virtual Team TeamA { get; set; }
        public virtual Team TeamB { get; set; }
        public virtual Team TeamReferee { get; set; }
        public int SetOneA { get; set; }
        public int SetOneB { get; set; }
        public int SetTwoA { get; set; }
        public int SetTwoB { get; set; }
        public DateTime BeginTime { get; set; }
        public virtual Terrain Terrain { get; set; }
        public virtual Level Level { get; set; }

        [NotMapped] 
        public Team Winner => SetOneA + SetTwoA > SetOneB + SetTwoB ? TeamA : TeamB;
        [NotMapped] 
        public Team Loser => SetOneA + SetTwoA < SetOneB + SetTwoB ? TeamA : TeamB;
    }
}
