using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class VehicleOwnerVehicleDto
    {
        public int VehicleOwnerVehicleID { get; set; }
        public int VehicleOwnerID { get; set; }
        public int VehicleID { get; set; }
        public bool IsDeleted { get; set; }    
        public List<VehicleOwner> VehicleOwners { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
