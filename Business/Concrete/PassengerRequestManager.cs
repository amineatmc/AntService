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
    public class PassengerRequestManager : IPassengerRequestService
    {
        IPassengerRequestDal _passengerRequestDal;
        public PassengerRequestManager(IPassengerRequestDal passengerRequestDal)
        {
            _passengerRequestDal = passengerRequestDal;
        }

        public async Task<IResult> Add(PassengerRequest entity)
        {
            if (entity != null)
            {
                
                entity.CreatedDate= DateTime.Now;
                _passengerRequestDal.Add(entity);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<PassengerRequest> GetbyId(int id)
        {
            var result = _passengerRequestDal.Get(x => x.PassengerRequestID == id);
            return new SuccessDataResult<PassengerRequest>(result);
        }

        public IDataResult<List<PassengerRequest>> GetbyRequestId(string id)
        {
            return new SuccessDataResult<List<PassengerRequest>>(_passengerRequestDal.GetList().Where(x=>x.RequestId==id).ToList());
        }

        public IDataResult<PassengerRequest> Update(PassengerRequestUpdateDto entity)
        {
            var data = _passengerRequestDal.Get(x=>x.PassengerRequestID==entity.PassengerRequestID);
            data.Status = entity.Status;
            _passengerRequestDal.Update(data);
            return new SuccessDataResult<PassengerRequest>(data);
        }
    }
}
