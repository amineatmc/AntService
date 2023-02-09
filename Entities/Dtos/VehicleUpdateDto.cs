using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class VehicleUpdateDto :IDto
    {
        public int VehicleID { get; set; }
        public string Plate { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public string LicenseNo { get; set; }
        public string LicenseDate { get; set; }
        public string LicenseExpiryDate { get; set; }
       
    }
}
