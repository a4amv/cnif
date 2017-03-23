using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobFairInformationForm.Database.Entities
{
    public class InformationForm2Location
    {
        [Key]
        public int InformationFormId { get; set; }
        public InformationForm InformationForm { get; set; }

        [Key]
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
