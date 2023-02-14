using Entities.Concrete;

namespace Entities.Concrete
{
    public class DriverVehicle
    {
        public int DriverVehicleID { get; set; }
        public int DriverID { get; set; }
       // public Driver Driver { get; set; }
        public int VehicleID { get; set; }
       // public Vehicle Vehicle { get; set; }
        public bool IsDeleted{ get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
