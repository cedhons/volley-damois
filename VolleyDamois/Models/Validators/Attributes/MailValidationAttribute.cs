using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyDamois.Models.Validators.Attributes
{
    public class MailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Player player = (Player)validationContext.ObjectInstance;
            var validator = new PlayerValidator(player);
            var errors = validator.ValidateMail();

            if (errors.Count > 0)
                return new ValidationResult(errors.First().Message);

            return ValidationResult.Success;
        }
    }
}
