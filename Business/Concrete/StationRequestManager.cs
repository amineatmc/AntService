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
    public class StationRequestManager : IStationRequestService
    {
        IStationRequestDal _stationRequestDal;
        public StationRequestManager(IStationRequestDal stationRequestDal)
        {
            _stationRequestDal = stationRequestDal;
        }

        public async Task<IResult> Add(StationRequest entity)
        {
            if (entity != null)
            {
                entity.CreatedDate = DateTime.Now;
                _stationRequestDal.Add(entity);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<StationRequest> GetbyId(int id)
        {
            var result = _stationRequestDal.Get(x => x.StationRequestID == id);
            return new SuccessDataResult<StationRequest>(result);
        }

        public IDataResult<List<StationRequest>> GetbyStationIdFilterDate(DateTimeFilterDto entity)
        {
            return new SuccessDataResult<List<StationRequest>>(_stationRequestDal.GetList().Where(x => x.StationId == entity.Id && x.CreatedDate >= entity.StartTime && x.CreatedDate <= entity.FinishTime).ToList());
        }

        public IDataResult<StationRequest> Update(StationRequestUpdateDto entity)
        {
            var data = _stationRequestDal.Get(x=>x.RequestId== entity.RequestId);
            data.Status = entity.Status;
            _stationRequestDal.Update(data);
            return new SuccessDataResult<StationRequest>(data);
        }
    }
}
