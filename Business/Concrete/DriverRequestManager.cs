﻿using Business.Abstract;
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
            var data = _driverRequest.Get(x=>x.DriverRequestID== entity.DriverRequestID);
            data.Status= entity.Status;
            data.RedirectionStatus= entity.RedirectionStatus;
            _driverRequest.Update(data);
            return new SuccessDataResult<DriverRequest>(data);
        }
    }
}
