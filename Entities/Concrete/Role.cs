using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Role
    {
        public int RoleID { get; set; }
        public string? RoleName { get; set; }
        public int Activity { get; set; }
    }
}
