using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class BoundaryUpdateDto
    {
        public int BoundaryID { get; set; }
        public int StationID { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}
