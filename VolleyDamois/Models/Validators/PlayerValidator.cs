using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolleyDamois.Models.Enum;

namespace VolleyDamois.Models.Validators
{
    public class PlayerValidator
    {
        private Player _player;
        public PlayerValidator(Player player)
        {
            _player = player;
        }

        public List<ValidationError> ValidateMail()
        {
            var errors = new List<ValidationError>();
            if (_player.Capitain && _player.Email == null)
                errors.Add(new ValidationError("Le courriel du capitaine est obligatoire."));
            return errors;
        }

        public List<ValidationError> ValidatePhone()
        {
            var errors = new List<ValidationError>();
            if (_player.Capitain && _player.PhoneNumber == null)
                errors.Add(new ValidationError("Le numéro de téléphone du capitaine est obligatoire."));
            return errors;
        }
    }
}
