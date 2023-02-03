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
    public class EfStationDal : EfEntityRepositoryBase<Station, AntTaksiContextDb>, IStationDal
    {
        public List<StationListDto> GetStationList()
        {
            using (var context = new AntTaksiContextDb())
            {
                var result = from station in context.Stations

                             join allUser in context.AllUsers on station.AllUserID equals allUser.AllUserID

                             select new StationListDto
                             {
                                 StationID = station.StationID,
                                 StationNumber = station.StationNumber,
                                 StationArea = station.StationArea,
                                 Longitude = station.Longitude,
                                 Latitude = station.Latitude,
                                 StationStatu = station.StationStatu,
                                 StationAuto = station.StationAuto,
                                 Ip = station.Ip,
                                 CreatedDate = station.CreatedDate,
                                 AllUserID = station.AllUserID,
                                 Activity = station.Activity,
                                 AllUsers = context.AllUsers.Where(x => x.AllUserID == station.AllUserID).ToList(),
                             };
                return result.ToList();
            }
        }
    }
}
