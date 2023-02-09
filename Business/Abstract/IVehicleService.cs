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
    public interface IVehicleService
    {
        Task<IResult> Add(Vehicle entity);
        IDataResult<Vehicle> GetbyId(int id);
        IDataResult<List<Vehicle>> GetAll();
        IDataResult<VehicleUpdateDto> Update(VehicleUpdateDto vehicleUpdateDto);
    }
}
