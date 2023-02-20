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
    public class DriverRequestManager : IDriverRequestService
    {
        IDriverRequestDal _driverRequest;
        public DriverRequestManager(IDriverRequestDal driverRequest)
        {
            _driverRequest = driverRequest;
        }

        public async Task<IResult> Add(DriverRequest entity)
        {
            if (entity != null)
            {
                entity.CreatedDate= DateTime.Now;
                _driverRequest.Add(entity);
                return new SuccessResult();
            }
           return new ErrorResult();
        }

        public IDataResult<List<DriverRequest>> GetbyDriverId(int id)
        {
            var result= _driverRequest.GetList().Where(x=>x.DriverID==id).ToList();
            return new SuccessDataResult<List<DriverRequest>>(result);
        }

        public IDataResult<List<DriverRequest>> GetbyDriverIdDate(DateTimeFilterDto entity)
        {
            return new SuccessDataResult<List<DriverRequest>>(_driverRequest.GetList().Where(x => x.DriverID == entity.Id && x.CreatedDate >= entity.StartTime && x.CreatedDate <= entity.FinishTime).ToList());
        }

        public IDataResult<DriverRequest> GetbyId(int id)
        {
            var result = _driverRequest.Get(x => x.DriverRequestID == id);
            return new SuccessDataResult<DriverRequest>(result);
        }

        public IDataResult<List<DriverRequest>> GetbyRequestId(string id)
        {
            return new SuccessDataResult<List<DriverRequest>>(_driverRequest.GetList().Where(x => x.RequestId == id).ToList());
        }

        public IDataResult<DriverRequest> Update(DriverRequestUpdateDto entity)
        {
            var data = _driverRequest.Get(x=>x.RequestId== entity.RequestID);
            data.Status= entity.Status;
            data.RedirectionStatus= entity.RedirectionStatus;
            _driverRequest.Update(data);
            return new SuccessDataResult<DriverRequest>(data);
        }
    }
}
