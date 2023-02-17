using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public async Task<IResult> Add(Vehicle entity)
        {
            entity.CreatedDate= DateTime.Now;
            entity.Activity = 1;
           _vehicleDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
          var result = _vehicleDal.Get(x=>x.VehicleID == id && x.Activity == 1 );
            if (result!=null)
            {
                result.Activity = 0;
                _vehicleDal.Update(result);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<Vehicle>> GetAll()
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetList().Where(x=>x.Activity==1).ToList());
        }

        public IDataResult<Vehicle> GetbyId(int id)
        {
            var result = _vehicleDal.Get(x => x.VehicleID == id && x.Activity==1);
            return new SuccessDataResult<Vehicle>(result);
        }

        public IDataResult<VehicleUpdateDto> Update(VehicleUpdateDto vehicleUpdateDto)
        {
            var result = _vehicleDal.Get(x=>x.VehicleID== vehicleUpdateDto.VehicleID && x.Activity == 1);
            if (result!=null)
            {
                result.Plate = vehicleUpdateDto.Plate;
                result.EngineNo= vehicleUpdateDto.EngineNo;
                result.ChasisNo= vehicleUpdateDto.ChasisNo;
                result.LicenseNo= vehicleUpdateDto.LicenseNo;
                result.LicenseDate= vehicleUpdateDto.LicenseDate;
                result.LicenseExpiryDate= vehicleUpdateDto.LicenseExpiryDate;
                result.TaximeterType= vehicleUpdateDto.TaximeterType;
                _vehicleDal.Update(result);
                return new SuccessDataResult<VehicleUpdateDto>(vehicleUpdateDto);
            }

            return new ErrorDataResult<VehicleUpdateDto>();
        }
    }
}
