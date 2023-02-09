using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {

        IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public async Task<IResult> Add(Reservation entity)
        {
            entity.CreatedDate= DateTime.Now;
            _reservationDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var result = _reservationDal.Get(x => x.ReservationID == id && x.IsDeleted == false);
            if (result != null)
            {
                result.IsDeleted = true;
                _reservationDal.Update(result);
                return new SuccessResult("Kayıt siilinidi");
            }
            return new ErrorResult();
        }

        public IDataResult<List<Reservation>> GetByDriverId(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetList().Where(x => x.DriverID == id && x.IsDeleted==false).ToList());
        }

        public IDataResult<List<Reservation>> GetByDriverIdActive(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetList().Where(x => x.DriverID == id && x.IsActive == true && x.IsDeleted==false).ToList());
        }

        public IDataResult<Reservation> GetbyId(int id)
        {          
            return new SuccessDataResult<Reservation>(_reservationDal.Get(x => x.ReservationID == id && x.IsDeleted == false));
        }

        public IDataResult<List<Reservation>> GetByPassengerId(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetList().Where(x => x.PassengerID == id && x.IsDeleted == false).ToList());
        }

        public IDataResult<List<Reservation>> GetByStationId(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetList().Where(x => x.StationID == id && x.IsDeleted == false).ToList());

        }

        public IDataResult<List<Reservation>> GetByStationIdActive(int id)
        {
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetList().Where(x => x.StationID == id && x.IsActive==false && x.IsDeleted==false).ToList());
        }

        public IDataResult<List<Reservation>> ReservationAssignment(ReservationAssignmentDto entity)
        {
            var rez = _reservationDal.Get(x=>x.ReservationID==entity.ReservationID);
            rez.DriverID= entity.DriverID;
            rez.IsActive = true;
            _reservationDal.Update(rez);
            return new SuccessDataResult<List<Reservation>>(_reservationDal.GetList().Where(x => x.ReservationID == entity.ReservationID).ToList());
        }
    }
}
