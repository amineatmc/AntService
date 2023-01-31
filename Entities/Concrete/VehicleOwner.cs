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
        public string OwnerName { get; set; }
        public int VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
        public int Activity { get; set; }
    }
}
