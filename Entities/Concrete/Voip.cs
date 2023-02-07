using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Voip :IEntity
    {
        public int VoipID { get; set; }
        public string ResponseId { get; set; }
        public string RequestId { get; set; }
        public DateTime CreatDate { get; set; }

    }
}
