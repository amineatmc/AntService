using AntalyaTaksiAccount.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AllUser
    {
        public int AllUserID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string MailAdress { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        //1:Driver 2:passenger 3:Station
        public int UserType { get; set; }
        public int? MailVerify { get; set; }
        public int Activity { get; set; }

    }
}
