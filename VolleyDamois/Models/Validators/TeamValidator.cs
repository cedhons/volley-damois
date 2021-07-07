using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolleyDamois.Models.Enum;

namespace VolleyDamois.Models.Validators
{
    public class TeamValidator
    {
        private Team _team;
        private Categories _category;

        public TeamValidator(Categories category, Team team)
        {
            _team = team;
            _category = category;
        }

        public List<ValidationError> ValidatePlayers()
        {
            var errors = new List<ValidationError>();

            ValidateNumberOfPlayers(errors);
            ValidateAffiliation(errors);
            ValidateFemale(errors);
            ValidateCapitain(errors);

            return errors;
        }

        private void ValidateAffiliation(List<ValidationError> errors)
        {
            if (TeamRules.AFFILIATION_NEEDED_FOR[_category])
            {
                if (_team.Players.Any(p => p.AffiliationNumber == null))
                {
                    errors.Add(new ValidationError(
                        $"Les joueurs de la catégorie {_category} doivent mentionné leur numéro d'affiliation."));
                }
            }
        }

        private void ValidateCapitain(List<ValidationError> errors)
        {
            int nbCaptains = _team.Players.Count(p => p.Capitain);
            if(nbCaptains != 1)
                errors.Add(new ValidationError(
                    "Il doit y avoir un capitaine dans une équipe."));
        }

        private void ValidateFemale(List<ValidationError> errors)
        {
            int nbFemale = _team.Players.Count(p => p.Gender == Genders.Female);

            if(nbFemale < TeamRules.MIN_FEMALE)
                errors.Add(new ValidationError("Il doit y avoir au moins une femme dans une équipe"));
        }

        private void ValidateNumberOfPlayers(List<ValidationError> errors)
        {
            Categories category = _category;

            int nbReservists = _team.Players.Count(p => p.Reservist);

            if(TeamRules.MAX_RESERVISTS_FOR[category] < nbReservists || TeamRules.NB_PLAYERS_FOR[category] != _team.Players.Count - nbReservists)
                errors.Add(new ValidationError("Le nombre de joueurs ou de réservistes est incorrect."));
        }
    }

    public class TeamRules
    {
        public static readonly IDictionary<Categories, int> NB_PLAYERS_FOR = new Dictionary<Categories, int>()
        {
            {Categories.Nationale, 3},
            {Categories.Provinciale, 4},
            {Categories.Loisir, 4},
        };
        public static readonly IDictionary<Categories, int> MAX_RESERVISTS_FOR = new Dictionary<Categories, int>()
        {
            {Categories.Nationale, 1},
            {Categories.Provinciale, 2},
            {Categories.Loisir, 2},
        };
        public static readonly IDictionary<Categories, bool> AFFILIATION_NEEDED_FOR = new Dictionary<Categories, bool>()
        {
            {Categories.Nationale, true},
            {Categories.Provinciale, true},
            {Categories.Loisir, false},
        };

        public static readonly int MIN_FEMALE = 1;

        public static readonly int MAX_PLAYERS = 6;
    }
}
