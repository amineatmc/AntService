using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class PassengerListDto
    {
        public int PassengerID { get; set; }
        public string IdNo { get; set; }
        public DateTime Birthday { get; set; }
        public bool Pet { get; set; }
        public bool Travel { get; set; }
        public bool Disabled { get; set; }
        public bool Banned { get; set; }
        public string Lang { get; set; }
        public string Lat { get; set; }
        public DateTime Created { get; set; }
        public int? AllUserID { get; set; }
        public int Activity { get; set; }
        public List<AllUser> Detail { get; set; }
    }
}
