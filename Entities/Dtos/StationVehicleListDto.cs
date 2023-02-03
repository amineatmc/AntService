using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StationVehicleListDto :IDto
    {
        public int StationVehicleID { get; set; }
        public List<Station> Stations{ get; set; }
        public List<Vehicle> Vehicles{ get; set; }

    }
}
