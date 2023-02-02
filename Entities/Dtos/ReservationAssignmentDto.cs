using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ReservationAssignmentDto :IDto
    {
        public int ReservationID { get; set; }      
        public int DriverID { get; set; }
    }
}
