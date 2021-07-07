using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VolleyDamois.Models.Enum;
using VolleyDamois.Models.Validators;
using VolleyDamois.Models.Validators.Attributes;

namespace VolleyDamois.Models.ViewModel
{
    public class TeamCreatorViewModel
    {
        [TeamValidation]
        public Team Team { get; set; }
        [Required]
        [Display(Name = "Catégorie")]
        public Categories Category { get; set; }
        public void FillWithDefaultPlayers()
        {
            while (Team.Players.Count < TeamRules.MAX_PLAYERS)
                Team.Players.Add(new Player());
        }
    }
}
