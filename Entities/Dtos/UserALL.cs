using Castle.Components.DictionaryAdapter;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserALL
    {
      
        public int AllUserID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? MailAdress { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }

        //1:Driver 2:passenger 3:Station
        public int? UserType { get; set; }
        public int? MailVerify { get; set; }
        public int? AllActivitiy { get; set; }

        public int? DriverID { get; set; }
        public string? IdNo { get; set; }
        public string? DriverLicenseNo { get; set; }
        public int? Rating { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? Pet { get; set; }
        public int? DStationID { get; set; }
        public string? DIp { get; set; }
        public bool? Penalty { get; set; }
        public DateTime? DCreatedDate { get; set; }
        public int? RoleID { get; set; }
        public int? DActivitiy { get; set; }
        public int? DAll { get; set; }

        public int? SStationID { get; set; }
        public int? StationNumber { get; set; }
        public string? StationArea { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public bool? StationStatu { get; set; }
        public bool? StationAuto { get; set; }
        public string? SIp { get; set; }
        public DateTime? SCreatedDate { get; set; }
        public int? SAll { get; set; }
        public int? SActivitiy { get; set; }


        public int? PassengerID { get; set; }
        public string? PIdNo { get; set; }
        public DateTime? PBirthday { get; set; }
        public bool? PPet { get; set; }
        public bool? Travel { get; set; }
        public bool? Disabled { get; set; }
        public bool? Banned { get; set; }
        public string? Lang { get; set; }
        public string? Lat { get; set; }
        public DateTime? Created { get; set; }
        public int? PAll { get; set; }
        public int? PActivitiy { get; set; }
    }
}
