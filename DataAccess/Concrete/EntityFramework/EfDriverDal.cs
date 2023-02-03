using AntalyaTaksiAccount.Models;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDriverDal : EfEntityRepositoryBase<Driver, AntTaksiContextDb>, IDriverDal
    {
        public List<DriverListDto> GetDrivers()
        {
            using (var context = new AntTaksiContextDb())
            {

                var result = from driver in context.Drivers
                             join alluser in context.AllUsers on driver.AllUserID equals alluser.AllUserID
                             select new DriverListDto
                             {
                                 DriverID = driver.DriverID,
                                 IdNo = driver.IdNo,
                                 DriverLicenseNo = driver.DriverLicenseNo,
                                 Rating = driver.Rating,
                                 BirthDay = driver.BirthDay,
                                 Pet = driver.Pet,
                                 StationID = driver.StationID,
                                 Ip = driver.Ip,
                                 Penalty = driver.Penalty,
                                 CreatedDate = driver.CreatedDate,
                                 RoleID = driver.RoleID,
                                 Activity = driver.Activity,
                                 AllUsers = context.AllUsers.Where(x => x.AllUserID == driver.AllUserID).ToList(),

                             };
                return result.ToList();
            }
        }

        //public List<DriverUpdateDto> GetUpdateDriver()
        //{
        //    using (var context = new AntTaksiContextDb())
        //    {
        //        var result = from driver in context.Drivers
        //                     join alluser in context.AllUsers on driver.AllUserID equals alluser.AllUserID
        //                     select new DriverUpdateDto
        //                     {
        //                         DriverID = driver.DriverID,
        //                         IdNo = driver.IdNo,
        //                         DriverLicenseNo = driver.DriverLicenseNo,
        //                         Rating = driver.Rating,
        //                         BirthDay = driver.BirthDay,
        //                         Pet = driver.Pet,
        //                         AllUsers = context.AllUsers.Where(x => x.AllUserID == driver.AllUserID).ToList(),

        //                     };
        //        return result.ToList();
        //    }
        //}
    }
}
