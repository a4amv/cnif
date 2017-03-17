using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobFairInformationForm.Models.InformationForm
{
    public class InformationFormViewModel
    {
        [Required]
        public string Location { get; set; }

        public string PreferredJob { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Telephone is required.")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int Allocation { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expected graduation date.")]
        public DateTime GraduationDate { get; set; }

        public string Education { get; set; }
    }
}
