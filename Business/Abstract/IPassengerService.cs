using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPassengerService
    {
      //  IDataResult<Passenger> GetAll(int id);
      IDataResult<List<PassengerListDto>>GetById(int id);
    }
}
