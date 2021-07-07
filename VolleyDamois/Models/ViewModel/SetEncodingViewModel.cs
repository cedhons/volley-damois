using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyDamois.Models.ViewModel
{
    public class SetEncodingViewModel
    {
        public int Id { get; set; }
        [Range(0, 100)]
        public int SetOneA { get; set; }
        [Range(0, 100)]
        public int SetOneB { get; set; }
        [Range(0, 100)]
        public int SetTwoA { get; set; }
        [Range(0, 100)]
        public int SetTwoB { get; set; }
    }
}
