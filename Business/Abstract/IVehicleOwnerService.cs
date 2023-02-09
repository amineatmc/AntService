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
    public interface IVehicleOwnerService
    {
        Task<IResult> Add(VehicleOwner entity);
        IDataResult<VehicleOwner> GetbyId(int id);
        IDataResult<List<VehicleOwner>> GetAll();
        IDataResult<VehicleOwner> GetbyTc(string tc);
        IDataResult<VehicleOwner> GetbyPhone(string phone);
        IResult Update(VehicleOwnerUpdateDto entity);
        IResult Delete(int id);

    }
}
