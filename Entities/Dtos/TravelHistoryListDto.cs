using AntalyaTaksiAccount.Models;
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class TravelHistoryListDto:IDto
    {
        public int TravelHistoryID { get; set; }
        public int StationId { get; set; }
        public int DriverId { get; set; }
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
        public bool Redirect { get; set; }
        public string Status { get; set; }
        // public List<AllUser> AllUsers{ get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Passenger> Passengers { get; set; }
    }
}
