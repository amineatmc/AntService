﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Boundary :IEntity
    {

        public int BoundaryID { get; set; }
        public int StationID { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
