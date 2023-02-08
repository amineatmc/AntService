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
    public class EfPassengerDal : EfEntityRepositoryBase<Passenger, AntTaksiContextDb>, IPassengerDal
    {
        public List<PassengerListDto> GetPassengers()
        {
            using (var context = new AntTaksiContextDb())
            {
                var result = from passenger in context.Passengers
                             join alluser in context.AllUsers on passenger.AllUserID equals alluser.AllUserID
                             select new PassengerListDto
                             {
                                 PassengerID = passenger.PassengerID,
                                 IdNo = passenger.IdNo,
                                 Birthday = passenger.Birthday,
                                 Pet = passenger.Pet,
                                 Travel = passenger.Travel,
                                 Disabled = passenger.Disabled,
                                 Banned = passenger.Banned,
                                 Lang = passenger.Lang,
                                 Lat = passenger.Lat,
                                 Created = passenger.Created,
                                 AllUserID = passenger.AllUserID,
                                 Activity = passenger.Activity,
                                 Detail = context.AllUsers.Where(x => x.AllUserID == passenger.AllUserID).ToList(),
                             };
                return result.ToList();
            }

        }
    }
}
