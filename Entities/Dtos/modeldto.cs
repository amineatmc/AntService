using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class modeldto
    {
        public int StationDriverID { get; set; }
        public int StationId { get; set; }
        public Station Station{ get; set;}
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
