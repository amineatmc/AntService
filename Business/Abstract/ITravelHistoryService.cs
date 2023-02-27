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
        IDataResult<List<TravelHistoryListDto>> GetAll();
        IDataResult<List<TravelHistoryListDto>> GetByStationId(int id);
        IDataResult<List<TravelHistoryListDto>> GetByStationIdDateTime(DateTimeFilterDto entity);
        IDataResult<List<TravelHistoryListDto>> GetByDriverIdDateTime(DateTimeFilterDto entity);
        IDataResult<TravelHistory> Update(TravelHistoryUpdateDto entity);
        IDataResult<EarningsDto> DriverEarnings(DateTimeFilterDto entity);

        

    }
}
