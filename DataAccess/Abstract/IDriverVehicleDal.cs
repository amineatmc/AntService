using AntalyaTaksiAccount.Models;
using Core.DataAccess;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDriverVehicleDal :IEntityRepository<DriverVehicle>
    {
        List<DriverVehicleListDto> GetDriverVehicles();
    }
}
