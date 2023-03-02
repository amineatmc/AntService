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
    public class EfPermitImageDal : EfEntityRepositoryBase<PermitImage, AntTaksiContextDb>, IPermitImageDal
    {
        public List<VehiclePermitImageDto> GetVehiclePermitImageList()
        {
            using (var context = new AntTaksiContextDb())
            {
                var result = from permit in context.PermitImages 
                             //join vehicle in context.Vehicles on permit.VehicleId equals vehicle.VehicleID
                             join img in context.PermitImages on permit.VehicleId equals img.VehicleId
                             select new VehiclePermitImageDto
                             {
                                // VehicleId=permit.VehicleId,
                                 //VehicleList = context.Vehicles.Where(x=>x.VehicleID==permit.VehicleId).ToList(),
                                 ImageList = context.PermitImages.Where(x=>x.VehicleId==permit.VehicleId).ToList(),
                             };
                return result.ToList();

            }

        }
    }
}
