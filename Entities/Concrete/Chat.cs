using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Chat : IEntity
    {
        public int ChatID { get; set; }
        public string RequestId { get; set; }
        public string Sender { get; set; }
        public int PassengerId { get; set; }
        public int DriverId { get; set; }
        public string Message { get; set; }
        public string Translate { get; set; }
        public string Language { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
