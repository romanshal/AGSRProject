using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.DataAccess.Entities
{
    public  class Patient : Entity
    {
        public string Use { get; set; }
        public string Family { get; set; }
        public string Gender { get; set; }  
        public DateTime BirthDate { get; set; }
    }
}
