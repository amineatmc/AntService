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
    public class EfStationVehicleDal : EfEntityRepositoryBase<StationVehicle, AntTaksiContextDb>, IStationVehicleDal
    {       
        public List<StationVehicleListDto> GetStationVehicleList()
        {
            using (var context = new AntTaksiContextDb())
            {
                var result = from stationVeh in context.StationVehicles
                             join station in context.Stations on stationVeh.StationId equals station.StationID
                             join veh in context.Vehicles on stationVeh.VehicleId equals veh.VehicleID    
                             
                             select new StationVehicleListDto
                             {
                                 StationVehicleID= stationVeh.StationVehicleID,
                                 Stations = context.Stations.Where(x => x.StationID == stationVeh.StationId).ToList(),
                                 Vehicles = context.Vehicles.Where(x => x.VehicleID == stationVeh.VehicleId).ToList(),
                             };
                return result.ToList();
            }
        }

        public List<StVehicleListDto> GetStVehicleList()
        {
            using (var context = new AntTaksiContextDb())
            {
                var result = from stationVeh in context.StationVehicles
                            
                             join vehicle in context.Vehicles on stationVeh.VehicleId equals vehicle.VehicleID

                             select new StVehicleListDto
                             {
                                 StationVehicleID = stationVeh.VehicleId,
                                 StationId = stationVeh.StationId,
                                 VehicleId = stationVeh.VehicleId,
                                 Stations= context.Stations.Where(x => x.StationID == stationVeh.StationId).ToList(),
                                 Vehicles = context.Vehicles.Where(x => x.VehicleID == stationVeh.VehicleId).ToList(),
                             };
                return result.ToList();
            }
        }
    }
}
