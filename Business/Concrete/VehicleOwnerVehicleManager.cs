using AntalyaTaksiAccount.Models;
using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VehicleOwnerVehicleManager : IVehicleOwnerVehicleService
    {
        IVehicleOwnerVehicleDal _vehicleOwnerVehicleDal;
        public VehicleOwnerVehicleManager(IVehicleOwnerVehicleDal vehicleOwnerVehicleDal)
        {
            _vehicleOwnerVehicleDal = vehicleOwnerVehicleDal;
        }

        public async Task<IResult> Add(VehicleOwnerVehicle entity)
        {
            entity.IsDeleted = false;
            entity.CreatedDate= DateTime.Now;
            _vehicleOwnerVehicleDal.Add(entity);
            return new SuccessResult(); 
        }

        public IResult Delete(int id)
        {
            var result = _vehicleOwnerVehicleDal.Get(x=>x.VehicleOwnerVehicleID== id);
            if (result!=null)
            {
                result.IsDeleted = true;
                _vehicleOwnerVehicleDal.Update(result);
                return new SuccessResult();
            }
            return new ErrorResult("Kayıt Yok");
        }

        public IDataResult<List<VehicleOwnerVehicleDto>> GetAll()
        {
            return new SuccessDataResult<List<VehicleOwnerVehicleDto>>(_vehicleOwnerVehicleDal.GetVehicleOwnerVehicle().Where(x=>x.IsDeleted==false).ToList());
        }

        public IDataResult<List<VehicleOwnerVehicleDto>> GetByVehicleId(int id)
        {
            return new SuccessDataResult<List<VehicleOwnerVehicleDto>>(_vehicleOwnerVehicleDal.GetVehicleOwnerVehicle().Where(x=>x.VehicleID==id).ToList());
        }

        public IDataResult<List<VehicleOwnerVehicleDto>> GetByVehicleOwnerId(int id)
        {
            return new SuccessDataResult<List<VehicleOwnerVehicleDto>>(_vehicleOwnerVehicleDal.GetVehicleOwnerVehicle().Where(x => x.VehicleOwnerID == id).ToList());

        }
    }
}
