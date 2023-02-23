using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Score : IEntity
    {
        public int ScoreId { get; set; }
        public int DriverId { get; set; }
        public int PassengerId { get; set; }
        public int Point { get; set; }
        public string RequestId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
