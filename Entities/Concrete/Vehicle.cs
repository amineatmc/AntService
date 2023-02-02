using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Plate { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public string LicenseNo { get; set; }
        public string LicenseDate { get; set; }
        public string LicenseExpiryDate { get; set; }

        //public int StationId { get; set; }
        public string TaximeterType { get; set; }
        public string Ip { get; set; }
        public bool Ceza { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Activity { get; set; }
    }
}
