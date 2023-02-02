using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DriverRequest:IEntity
    {
        public int DriverRequestID { get; set; }
        public string RequestId { get; set; }
        public int DriverID { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool RedirectionStatus { get; set; }
    }
}
