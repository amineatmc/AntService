using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTravelHistoryDal : EfEntityRepositoryBase<TravelHistory, AntTaksiContextDb>, ITravelHistoryDal
    {
        public List<TravelHistoryListDto> GetTravelHistory()
        {
            using (var context = new AntTaksiContextDb())
            {
                var result = from travel in context.TravelHistories
                             join driver in context.Drivers on travel.DriverId equals driver.DriverID
                             join passenger in context.Passengers on travel.PassengerId equals passenger.PassengerID
                             //join drivers in context.AllUsers on travel.DriverId equals drivers.
                             select new TravelHistoryListDto
                             {
                                 TravelHistoryID = travel.TravelHistoryID,
                                 Passengers = context.Passengers.Where(x => x.PassengerID == travel.PassengerId).ToList(),
                                 Drivers = context.Drivers.Where(x => x.DriverID == travel.DriverId).ToList(),
                                 StationId = travel.StationId,
                                 RequestId= travel.RequestId,
                                 PaymentTypeId= travel.PaymentTypeId,
                                 Price = travel.Price,
                                 Distance = travel.Distance,
                                 Duration = travel.Duration,
                                 Description= travel.Description,
                                 StartLocation= travel.StartLocation,
                                 FinishLocation = travel.FinishLocation,
                                 StartTime= travel.StartTime,
                                 FinishTime= travel.FinishTime
                             };
                return result.ToList();

            }
        }
    }
}
