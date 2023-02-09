using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Reservation : IEntity
    {
        public int ReservationID { get; set; }
        public int PassengerID { get; set; }
        public int DriverID { get; set; }
        public int StationID { get; set; }
        public string StartAddress { get; set; }
        public string FinishAddress { get; set; }
        public DateTime ReservationTime { get; set; }
        public bool Confirmation { get; set; }
        public bool Cancel { get; set; }
        public int Statu { get; set; }
        public string StartLat { get; set; }
        public string StartLong { get; set; }
        public string FinishLat { get; set; }
        public string FinishLong { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive{ get; set; }
        public bool IsDeleted { get; set; }
    }
}
