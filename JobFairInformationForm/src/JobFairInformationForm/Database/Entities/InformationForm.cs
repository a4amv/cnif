using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobFairInformationForm.Database.Entities
{
    public class InformationForm
    {
        [Key]
        public int Id { get; set; }

        public string Location { get; set; }

        public string PreferredJob { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Allocation { get; set; }

        public DateTime GraduationDate { get; set; }

        public string Education { get; set; }

        public string NoteString { get; set; }

        public virtual List<InformationForm2Location> InformationForm2Locations { get; set; } = new List<InformationForm2Location>();

        public DateTime CurrentDate { get; set; } = DateTime.Now;
    }
}
