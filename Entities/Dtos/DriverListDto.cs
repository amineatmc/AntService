using AntalyaTaksiAccount.Models;
using Core.Entities;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class DriverListDto : IDto
    {
        public int DriverID { get; set; }
        public string IdNo { get; set; }
        public string DriverLicenseNo { get; set; }
        public int? Rating { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Pet { get; set; }
        public int StationID { get; set; }
        public string Ip { get; set; }
        public bool Penalty { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? RoleID { get; set; }
        public int? AllUserID { get; set; }
        public int Activity { get; set; }
        public List<AllUser> AllUsers { get; set; }

    }
}
