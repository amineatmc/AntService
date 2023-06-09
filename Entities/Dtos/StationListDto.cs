﻿using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StationListDto : IDto
    {
        public int StationID { get; set; }
        public int StationNumber { get; set; }
        public string StationArea { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool StationStatu { get; set; }
        public bool StationAuto { get; set; }
        public string Ip { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? AllUserID { get; set; }
        public int Activity { get; set; }
        public List<AllUser> AllUsers { get; set; }
    }
}
