using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfVehicleOwnerVehicleDal : EfEntityRepositoryBase<VehicleOwnerVehicle, AntTaksiContextDb>, IVehicleOwnerVehicleDal
    {
        public List<VehicleOwnerVehicleDto> GetVehicleOwnerVehicle()
        {
            using (var context = new AntTaksiContextDb())
            {
                var result = from ownerVeh in context.VehicleOwnerVehicles
                             join vehicle in context.Vehicles on ownerVeh.VehicleID equals vehicle.VehicleID
                             join owner in context.VehicleOwners on ownerVeh.VehicleOwnerID equals owner.VehicleOwnerID

                             select new VehicleOwnerVehicleDto
                             {
                                 VehicleOwnerVehicleID=ownerVeh.VehicleOwnerVehicleID,
                                 VehicleID= ownerVeh.VehicleID,
                                 Vehicles=context.Vehicles.Where(x=>x.VehicleID==ownerVeh.VehicleID).ToList(),
                                 VehicleOwnerID=ownerVeh.VehicleOwnerID,
                                 VehicleOwners=context.VehicleOwners.Where(x=>x.VehicleOwnerID==ownerVeh.VehicleOwnerID).ToList(),   
                                 IsDeleted=ownerVeh.IsDeleted,
                             };
                return result.Where(x => x.IsDeleted == false).ToList();
            }
        }
    }
}
