using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class VehicleAddDto : IDto
    {
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
        public IFormFile[]? CarImages { get; set; }

    }
}
