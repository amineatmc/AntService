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
    public class DriverCancelTravelManager : IDriverCancelTravelService
    {
        IDriverCancelTravelDal _driverCancelTravel;
        public DriverCancelTravelManager(IDriverCancelTravelDal driverCancelTravel)
        {
            _driverCancelTravel = driverCancelTravel;
        }

        public IResult Add(DriverCancelTravel entity)
        {
            if (entity.CancelTextId!=5)
            {
                entity.CancelReason = "";  
            }
            entity.CreatedDate= DateTime.Now;
            _driverCancelTravel.Add(entity);
            return new SuccessResult();
        }

        public IDataResult<List<DriverCancelTravel>> GetByDriverId(int id)
        {
            return new SuccessDataResult<List<DriverCancelTravel>>(_driverCancelTravel.GetList().Where(x=>x.DriverId==id).ToList());
        }
    }
}
