using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class VehicleOwnerUpdateDto:IDto
    {
        public int VehicleOwnerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string TCNo { get; set; }
        public string Birthday { get; set; }
    }
}
