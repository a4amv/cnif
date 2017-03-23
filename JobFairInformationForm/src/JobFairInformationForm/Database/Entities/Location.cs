using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFairInformationForm.Database.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<InformationForm2Location> InformationForm2Locations { get; set; } = new List<InformationForm2Location>();
    }
}
