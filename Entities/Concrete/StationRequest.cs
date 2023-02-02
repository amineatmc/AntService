using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StationRequest:IEntity
    {
        public int StationRequestID { get; set; }
        public string RequestId { get; set; }
        public int StationId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
