using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VolleyDamois.Models.Enum;

namespace VolleyDamois.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public Categories Name { get; set; }
        public virtual IList<Terrain> Terrains { get; set; }
    }
}
