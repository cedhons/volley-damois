using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VolleyDamois.Models.ViewModel;

namespace VolleyDamois.Models.Validators.Attributes
{
    public class TeamValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var teamVM = (TeamCreatorViewModel)validationContext.ObjectInstance;
            var validator = new TeamValidator(teamVM.Category, teamVM.Team);
            var errors = validator.ValidatePlayers();

            if (errors.Count > 0) 
                return new ValidationResult(errors.First().Message);
            
            return ValidationResult.Success;
        }
    }
}
