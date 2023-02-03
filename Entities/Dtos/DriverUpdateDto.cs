using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class DriverUpdateDto : IDto
    {
        public int DriverID { get; set; }
        public string IdNo { get; set; }
        public string DriverLicenseNo { get; set; }
        public int? Rating { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Pet { get; set; }
    }
}
