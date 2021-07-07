using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VolleyDamois.Models.Enum;
using VolleyDamois.Models.Validators;
using VolleyDamois.Models.Validators.Attributes;

namespace VolleyDamois.Models
{
    public class Player
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "La longeur maximale de 50 caractères est dépassée")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Le numéro d'affilliation ne doit être composé que de chiffres")]
        [Display(Name = "Numéro d'affiliation")]
        public string AffiliationNumber { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [MaxLength(50)]
        [RegularExpression(@"^\D{2,}$", ErrorMessage="Le nom doit être composé que de lettres et doit avoir au moins deux caractères")]
        [Display(Name = "Nom")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [MaxLength(50)]
        [RegularExpression(@"^\D{2,}$", ErrorMessage = "Le prénom doit être composé que de lettres et doit avoir au moins deux caractères")]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Sexe")]
        public Genders Gender { get; set; }
        [Display(Name = "Est capitaine")]
        public bool Capitain { get; set; }
        [Display(Name = "Est réserviste")]
        public bool Reservist { get; set; }
        [Required(ErrorMessage = "L'adresse est obligatoire")]
        [MaxLength(100, ErrorMessage = "La longeur maximale de 100 caractères est dépassée")]
        [Display(Name = "Adresse")]
        public string Adress { get; set; }
        [Phone]
        [MaxLength(50, ErrorMessage = "La longeur maximale de 50 caractères est dépassée")]
        [PhoneValidation(ErrorMessage = "Le numéro de téléphone n'est pas valide'")]
        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "La longeur maximale de 50 caractères est dépassée")]
        [MailValidation(ErrorMessage = "Le courriel n'est pas valide")]
        [Display(Name = "Courriel")]
        public string Email { get; set; }
    }
}