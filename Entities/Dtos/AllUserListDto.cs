using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class AllUserListDto :IDto
    {

        public int AllUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAdress { get; set; }
        public int UserType { get; set; }
    }
}
