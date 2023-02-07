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
    public class StationVehicleManager : IStationVehicleService
    {
        IStationVehicleDal _stationVehicleDal;
        public StationVehicleManager(IStationVehicleDal stationVehicleDal)
        {
            _stationVehicleDal = stationVehicleDal;
        }

        public async Task<IResult> Add(StationVehicle entity)
        {
            entity.CreatedDate= DateTime.Now;
            _stationVehicleDal.Add(entity);
            return new SuccessResult();
        }    

        public IDataResult<List<StationVehicle>> GetAll()
        {
            return new SuccessDataResult<List<StationVehicle>>(_stationVehicleDal.GetList().ToList());
        }

        public IDataResult<List<StationVehicleListDto>> GetById(int id)
        {
            return new SuccessDataResult<List<StationVehicleListDto>>(_stationVehicleDal.GetStationVehicleList().Where(x => x.StationVehicleID == id).ToList());
        }

        public IDataResult<List<StVehicleListDto>> GetByStationId(int id)
        {
            return new SuccessDataResult<List<StVehicleListDto>>(_stationVehicleDal.GetStVehicleList().Where(x => x.StationId == id).ToList());  
        }
    }
}
