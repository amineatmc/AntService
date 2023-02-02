using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPassengerRequestService
    {
        Task<IResult> Add(PassengerRequest entity);
        IDataResult<PassengerRequest> GetbyId(int id);
        IDataResult<List<PassengerRequest>> GetbyRequestId(string id);
    }
}
