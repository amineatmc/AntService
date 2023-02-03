﻿using AntalyaTaksiAccount.Models;
using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
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

        public IDataResult<List<DriverVehicleListDto>> GetAll()
        {
            return new SuccessDataResult<List<DriverVehicleListDto>>(_driverVehicleDal.GetDriverVehicles().ToList());
        }

        public IDataResult<List<DriverVehicleListDto>> GetByDriverId(int id)
        {
            return new SuccessDataResult<List<DriverVehicleListDto>>(_driverVehicleDal.GetDriverVehicles().Where(x=>x.DriverId==id).ToList());

        }

        public IDataResult<List<DriverVehicleListDto>> GetByVehicleId(int id)
        {
            return new SuccessDataResult<List<DriverVehicleListDto>>(_driverVehicleDal.GetDriverVehicles().Where(x => x.VehicleId == id).ToList());

        }
    }
}
