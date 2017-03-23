using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JobFairInformationForm.Database.Entities;

namespace JobFairInformationForm.Models.InformationForm
{
    public class InformationFormViewModel
    {

        public int Id { get; set; }

        //[Required(ErrorMessage = "Location is required.")]
        /// <summary>
        /// Only output value
        /// </summary>
        public string Location { get; set; }

        public List<Checkbox> LocationCheckboxes { get; set; } = new List<Checkbox>();

        /// <summary>
        /// Incomming data from post
        /// </summary>
        public Dictionary<int, string> CheckedLocations { get; set; } = new Dictionary<int, string>();

        // [Required(ErrorMessage = "Preferred job is required.")]
        public string PreferredJob { get; set; }

        public string PreferredJobOther { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Telephone is required.")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Allocation is required.")]
        public int Allocation { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expected graduation date")]
        public DateTime GraduationDate { get; set; }

        public string Education { get; set; }

        public string NoteString { get; set; }
    }
}
