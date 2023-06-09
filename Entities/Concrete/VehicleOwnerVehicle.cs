﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VehicleOwnerVehicle:IEntity
    {
        public int VehicleOwnerVehicleID { get; set; }
        public int VehicleOwnerID { get; set; }
        public int VehicleID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
