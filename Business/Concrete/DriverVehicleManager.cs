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
    public class DriverVehicleManager : IDriverVehicleService
    {
        IDriverVehicleDal _driverVehicleDal;
        public DriverVehicleManager(IDriverVehicleDal driverVehicleDal)
        {
            _driverVehicleDal = driverVehicleDal;
        }

        public async Task<IResult> Add(DriverVehicle entity)
        {
            _driverVehicleDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var entity = _driverVehicleDal.Get(x=>x.DriverVehicleID== id && x.IsDeleted==false);
            if (entity!=null)
            {
                entity.IsDeleted = true;
                _driverVehicleDal.Update(entity);
                return new SuccessResult("Kayıt Silindi");
            }
            return new ErrorResult("Kayıt Yok");
        }

        public IDataResult<List<DriverVehicleListDto>> GetAll()
        {
            return new SuccessDataResult<List<DriverVehicleListDto>>(_driverVehicleDal.GetDriverVehicles().Where(x=>x.IsDeleted==false).ToList());
        }

        public IDataResult<List<DriverVehicleListDto>> GetByDriverId(int id)
        {
            return new SuccessDataResult<List<DriverVehicleListDto>>(_driverVehicleDal.GetDriverVehicles().Where(x=>x.DriverId==id && x.IsDeleted==false).ToList());
        }

        public IDataResult<List<DriverVehicleListDto>> GetByVehicleId(int id)
        {
            return new SuccessDataResult<List<DriverVehicleListDto>>(_driverVehicleDal.GetDriverVehicles().Where(x => x.VehicleId == id && x.IsDeleted==false).ToList());
        }
    }
}
