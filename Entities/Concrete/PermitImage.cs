using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PermitImage: IDto
    {
        public int PermitImageID { get; set; }
        public int VehicleId { get; set; }
        public string? Path { get; set; }
        public bool IsDeleted { get; set; }
    }
}
