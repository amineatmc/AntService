using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DriverCancelTravel: IEntity
    {
        public int ID { get; set; }
        public int DriverId { get; set; }
        public string RequestId { get; set; }
        public string CancelReason { get; set; }
        public int CancelTextId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
