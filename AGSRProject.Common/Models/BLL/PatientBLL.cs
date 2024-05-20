using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.Common.Models.BLL
{
    public class PatientBLL
    {
        public NameBLL Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }

        public PatientBLL()
        {
            Name = new NameBLL();
        }
    }
}
