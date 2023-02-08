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
    public class PassengerManager : IPassengerService
    {
        IPassengerDal _passengerDal;
        public PassengerManager(IPassengerDal passengerDal)
        {
            _passengerDal = passengerDal;
        }

        public IDataResult<List<PassengerListDto>> GetById(int id)
        {
           return new SuccessDataResult<List<PassengerListDto>>(_passengerDal.GetPassengers().Where(x=>x.PassengerID==id).ToList());
        }
    }
}
