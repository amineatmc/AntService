using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VehicleOwner
    {
        public int VehicleOwnerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string TCNo { get; set; }
        public string Birthday { get; set; }
        public string Ip { get; set; }
        public string CreatedUser  { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Activity { get; set; }
    }
}
