using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TravelHistory:IEntity
    {
        public int TravelHistoryID { get; set; }
        public int PassengerId { get; set; }
        public int DriverId { get; set; }
        public int StationId { get; set; }
        public string RequestId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal Price { get; set; }
        public string Distance { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string StartLocation { get; set; }
        public string FinishLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
