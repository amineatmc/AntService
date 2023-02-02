using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PassengerRequest
    {
        public int PassengerRequestID { get; set; }        
        public string RequestId { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Status { get; set; }
        public int PassengerID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
