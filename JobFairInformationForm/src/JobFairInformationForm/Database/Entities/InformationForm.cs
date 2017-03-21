using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFairInformationForm.Database.Entities
{
    public class InformationForm
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public string PreferredJob { get; set; }

        public string Name { get; set; }
        
        public string Surname { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Allocation { get; set; }

        public DateTime GraduationDate { get; set; }

        public string Education { get; set; }

        public string NoteString { get; set; }
    }
}
