using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class DriverRequestUpdateDto:IDto
    {
        public int DriverRequestID { get; set; }
        public string Status { get; set; }
        public bool RedirectionStatus { get; set; }

    }
}
