using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StationRequestUpdateDto:IDto
    {
        public string RequestId { get; set; } 
        public string Status { get; set; }
    }
}
