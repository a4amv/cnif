﻿using System;
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


        /// <summary>
        /// Only output value
        /// </summary>
        //[Required(ErrorMessage = "Location is required.")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        public List<Checkbox> LocationCheckboxes { get; set; } = new List<Checkbox>();

        /// <summary>
        /// Incomming data from post
        /// </summary>
        public Dictionary<int, string> CheckedLocations { get; set; } = new Dictionary<int, string>();

        //[Required(ErrorMessage = "Preferred job is required.")]
        [Display(Name = "Preferred")]
        [Required(ErrorMessage = "Preferred job is required.")]
        public string PreferredJob { get; set; }

        public string PreferredJobOther { get; set; }

        [Display(Name = "CN University")]
        public bool CNUniversity { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Telephone is required.")]
        [RegularExpression(@"^\+?(\d[\d- ]+)?(\([\d- ]+\))?[\d- ]+\d$", ErrorMessage = "Telephone number is not valid.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Allocation")]
        [Required(ErrorMessage = "Allocation is required.")]
        [Range(20, 40, ErrorMessage = "The field allocation must be between 20 and 40.")]
        public int Allocation { get; set; } = 20;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expected graduation date")]
        public DateTime GraduationDate { get; set; }

        [Display(Name = "Education")]
        public string Education { get; set; }

        [Display(Name = "Note")]
        public string NoteString { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Entry date")]
        public DateTime CurrentDate { get; set; }
    }
}
