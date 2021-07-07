using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using VolleyDamois.Models.Enum;
using VolleyDamois.Models.Validators;
using VolleyDamois.Models.Validators.Attributes;

namespace VolleyDamois.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name= "Nom de l'équipe")]
        [RegularExpression(@"^\D{2,}$", ErrorMessage = "Le nom de l'équipe doit être composé que de lettres et doit avoir au moins deux caractères")]
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        [Display(Name = "Membres")]
        public virtual IList<Player> Players { get; set; }
        [Display(Name = "Réserver un emplacement pour loger")]
        public bool Camping { get; set; }
        [BindNever]
        public bool Confirmation { get; set; }

        public virtual IList<Confrontation> ConfrontationsA { get; set; }
        public virtual IList<Confrontation> ConfrontationsB { get; set; }

        [NotMapped]
        public int Points
        {
            get
            {
                var countVictories = ConfrontationsA?.Count(c => c.SetOneA + c.SetTwoA > c.SetOneB + c.SetTwoB) ?? 0;
                countVictories += ConfrontationsB?.Count(c => c.SetOneA + c.SetTwoA < c.SetOneB + c.SetTwoB) ?? 0;
                return countVictories * 2;
            }
        }

        [NotMapped]
        public int PointsFor
        {
            get
            {
                var countFor = ConfrontationsA?.Aggregate(0, (a, c) => a + c.SetOneA + c.SetTwoA) ?? 0;
                countFor += ConfrontationsB?.Aggregate(0, (a, c) => a + c.SetOneB + c.SetTwoB) ?? 0;
                return countFor;
            }
        }

        [NotMapped]
        public int PointsAgainst
        {
            get
            {
                var countAgainst = ConfrontationsA?.Aggregate(0, (a, c) => a + c.SetOneB + c.SetTwoB) ?? 0;
                countAgainst += ConfrontationsB?.Aggregate(0, (a, c) => a + c.SetOneA + c.SetTwoA) ?? 0;
                return countAgainst;
            }
        }
    }
}
