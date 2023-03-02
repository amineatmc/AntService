using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class VehiclePermitImageDto : IDto
    {
       // public int VehicleId { get; set; }
        //public List<Vehicle> VehicleList { get; set; }
        public List<PermitImage> ImageList { get; set; }
    }
}
