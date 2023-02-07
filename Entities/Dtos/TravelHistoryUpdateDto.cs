using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class TravelHistoryUpdateDto:IDto
    {    
        public string RequestId { get; set; }      
        public bool Redirect { get; set; }
        public string Status { get; set; }
    }
}
