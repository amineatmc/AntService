using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class DriverVehicleListDto :IDto
    {
        public int DriverVehicleID { get; set; }       
        public bool IsDeleted{ get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Driver> Drivers{ get; set; }
        public List<Vehicle> Vehicles{ get; set; }

    }
}
