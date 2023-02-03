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
    public interface IStationVehicleService
    {
        IDataResult<List<StationVehicleListDto>> GetById(int id);
        Task<IResult> Add(StationVehicle entity);
        IDataResult<List<StationVehicle>> GetAll();
        IDataResult<List<StVehicleListDto>> GetByStationId(int id);    
    }
}
