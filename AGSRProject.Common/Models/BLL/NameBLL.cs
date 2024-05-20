using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.Common.Models.BLL
{
    public class NameBLL
    {
        public string Id { get; set; }
        public string Use { get; set; }
        public string Family { get; set; }
        public string[] Given { get; set; }

        public NameBLL()
        {
            this.Given = new string[2];
        }
    }
}
