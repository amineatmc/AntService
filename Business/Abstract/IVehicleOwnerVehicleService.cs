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
    public interface IVehicleOwnerVehicleService
    {
        Task<IResult> Add(VehicleOwnerVehicle entity);
        IDataResult<List<VehicleOwnerVehicleDto>> GetAll();
        IDataResult<List<VehicleOwnerVehicleDto>> GetByVehicleId(int id);
        IDataResult<List<VehicleOwnerVehicleDto>> GetByVehicleOwnerId(int id);
        IResult Delete(int id);
    }
}
