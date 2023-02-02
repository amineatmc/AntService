using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PaymentType :IEntity
    {
        public int PaymentTypeID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
