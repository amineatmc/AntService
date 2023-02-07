using AntalyaTaksiAccount.Models;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDriverVehicleDal : EfEntityRepositoryBase<DriverVehicle, AntTaksiContextDb>, IDriverVehicleDal
    {
        public List<DriverVehicleListDto> GetDriverVehicles()
        {
            using (var context = new AntTaksiContextDb())
            {
                var result = from driverVeh in context.DriverVehicles
                             join driver in context.Drivers on driverVeh.DriverID equals driver.DriverID
                             join veh in context.Vehicles on driverVeh.VehicleID equals veh.VehicleID

                             select new DriverVehicleListDto
                             {
                                 DriverVehicleID = driverVeh.DriverVehicleID,
                                 CreatedDate = driverVeh.CreatedDate,
                                 Activity=driverVeh.Activity,
                                 DriverId=driverVeh.DriverID,
                                 VehicleId=driverVeh.VehicleID,
                                 Drivers= context.Drivers.Where(x => x.DriverID == driverVeh.DriverID).ToList(),                            
                                 Vehicles = context.Vehicles.Where(x => x.VehicleID == driverVeh.VehicleID).ToList(),
                             };
                return result.ToList();
            }
        }
    }
}
