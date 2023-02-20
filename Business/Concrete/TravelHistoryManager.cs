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
    public class TravelHistoryManager : ITravelHistoryService
    {
        ITravelHistoryDal _travelHistoryDal;
        public TravelHistoryManager(ITravelHistoryDal travelHistoryDal)
        {
            _travelHistoryDal = travelHistoryDal;
        }

        public async Task<IResult> Add(TravelHistory entity)
        {
            if (entity!=null)
            {
                _travelHistoryDal.Add(entity);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<TravelHistory>> DriverTravel(int id)
        {
            return new SuccessDataResult<List<TravelHistory>>(_travelHistoryDal.GetList().Where(x => x.DriverId == id).ToList());
        }

        public IDataResult<List<TravelHistoryListDto>> GetAll()
        {
            return new SuccessDataResult<List<TravelHistoryListDto>>(_travelHistoryDal.GetTravelHistory().ToList());
        }

        public IDataResult<List<TravelHistoryListDto>> GetByStationIdDateTime(DateTimeFilterDto entity)
        {
            return new SuccessDataResult<List<TravelHistoryListDto>>(_travelHistoryDal.GetTravelHistory().Where(x=>x.StationId==entity.Id && x.StartTime>=entity.StartTime && x.StartTime<=entity.FinishTime).ToList());
        }

        public IDataResult<List<TravelHistory>> GetByDriverId(int id)
        {
            return new SuccessDataResult<List<TravelHistory>>(_travelHistoryDal.GetList().Where(x => x.DriverId == id).ToList());
        }

        public IDataResult<TravelHistory> GetbyId(int id)
        {
            return new SuccessDataResult<TravelHistory>(_travelHistoryDal.Get(x=>x.TravelHistoryID==id));
        }

        public IDataResult<List<TravelHistory>> GetByPassengerId(int id)
        {
            return new SuccessDataResult<List<TravelHistory>>(_travelHistoryDal.GetList().Where(x => x.PassengerId == id).ToList());
        }

        public IDataResult<List<TravelHistoryListDto>> GetByRequestId(string id)
        {
            return new SuccessDataResult<List<TravelHistoryListDto>>(_travelHistoryDal.GetTravelHistory().Where(x=>x.RequestId==id).ToList());
        }

        public IDataResult<List<TravelHistoryListDto>> GetByStationId(int id)
        {
            return new SuccessDataResult<List<TravelHistoryListDto>>(_travelHistoryDal.GetTravelHistory().Where(x=>x.StationId==id).ToList());
        }

        public IDataResult<List<TravelHistory>> PassengerTravel(int id)
        {
            return new SuccessDataResult<List<TravelHistory>>(_travelHistoryDal.GetList().Where(x => x.PassengerId == id).ToList());
        }

        public IDataResult<TravelHistory> Update(TravelHistoryUpdateDto entity)
        {
           var data = _travelHistoryDal.Get(x=>x.RequestId== entity.RequestId);
            data.Status = entity.Status;
            data.Redirect=entity.Redirect;
            _travelHistoryDal.Update(data);
            return new SuccessDataResult<TravelHistory>(data);

        }

        public IDataResult<List<TravelHistoryListDto>> GetByDriverIdDateTime(DateTimeFilterDto entity)
        {
            return new SuccessDataResult<List<TravelHistoryListDto>>(_travelHistoryDal.GetTravelHistory().Where(x => x.DriverId == entity.Id && x.StartTime >= entity.StartTime && x.StartTime <= entity.FinishTime).ToList());

        }
    }
}
