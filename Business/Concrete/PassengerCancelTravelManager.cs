using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PassengerCancelTravelManager : IPassengerCancelTravelService
    {
        IPassengerCancelTravelDal _passengerCancelTravel;
        public PassengerCancelTravelManager(IPassengerCancelTravelDal passengerCancelTravel)
        {
            _passengerCancelTravel = passengerCancelTravel;
        }

        public IResult Add(PassengerCancelTravel entity)
        {
            if (entity.CancelTextId != 5)
            {
                entity.CancelReason = "";
            }
            entity.CreatedDate = DateTime.Now;
            _passengerCancelTravel.Add(entity);
            return new SuccessResult();
        }

        public IDataResult<List<PassengerCancelTravel>> GetByPassengerId(int id)
        {
            return new SuccessDataResult<List<PassengerCancelTravel>>(_passengerCancelTravel.GetList().Where(x=>x.PassengerId==id).ToList());
        }
    }
}
