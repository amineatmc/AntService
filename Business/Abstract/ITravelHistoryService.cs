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
    public interface ITravelHistoryService
    {
        Task<IResult> Add(TravelHistory entity);
        IDataResult<TravelHistory> GetbyId(int id);
        IDataResult<List<TravelHistory>> GetByPassengerId(int id);
        IDataResult<List<TravelHistory>> GetByDriverId(int id);
        IDataResult<List<TravelHistory>> PassengerTravel(int id);
        IDataResult<List<TravelHistory>> DriverTravel(int id);
        IDataResult<List<TravelHistoryListDto>> GetByRequestId(string id);
        IDataResult<TravelHistory> Update(TravelHistoryUpdateDto entity);

        

    }
}
