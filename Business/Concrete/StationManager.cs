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
    public class StationManager : IStationService
    {
        IStationDal _stationDal;
        public StationManager(IStationDal stationDal)
        {
            _stationDal = stationDal;
        }

        public IDataResult<List<StationListDto>> GetAll()
        {
           return new SuccessDataResult<List<StationListDto>>(_stationDal.GetStationList().Where(x=>x.Activity==1).ToList());
        }

        public IDataResult<List<StationListDto>> GetByStationId(int id)
        {
            return new SuccessDataResult<List<StationListDto>>(_stationDal.GetStationList().Where(x=>x.StationID==id && x.Activity==1).ToList());

        }
    }
}
