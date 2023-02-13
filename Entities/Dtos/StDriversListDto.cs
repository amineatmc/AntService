using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StVehicleListDto
    {
        public int StationVehicleID { get; set; }
        public int StationId { get; set; }
        public int VehicleId { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Station>  Stations{ get; set; }
    }
}
