using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
           _vehicleDal.Add(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Vehicle>> GetAll()
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetList());
        }

        public IDataResult<Vehicle> GetbyId(int id)
        {
            var result = _vehicleDal.Get(x => x.VehicleID == id);
            return new SuccessDataResult<Vehicle>(result);
        }
    }
}
