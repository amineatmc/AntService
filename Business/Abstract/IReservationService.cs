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
    public interface IReservationService
    {
        Task<IResult> Add(Reservation entity);
        IDataResult<Reservation> GetbyId(int id);
        IDataResult<List<Reservation>> GetByPassengerId(int id);
        IDataResult<List<Reservation>> GetByDriverId(int id);
        IDataResult<List<Reservation>> GetByStationId(int id);
        IDataResult<List<Reservation>> GetByStationIdActive(int id);
        IDataResult<List<Reservation>> GetByDriverIdActive(int id);
        IDataResult<List<Reservation>> ReservationAssignment(ReservationAssignmentDto entity);

        
    }
}
