using AntalyaTaksiAccount.Models;
using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
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
    }
}
