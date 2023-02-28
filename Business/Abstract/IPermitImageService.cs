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
    public interface IPermitImageService
    {
        IResult Add(PermitImage entity);
        IDataResult<List<PermitImage>> GetListByVehicleId(int VehicleId);
        IDataResult<List<VehiclePermitImageDto>> GetListVehiclePermitImage(int VehicleId);

    }
}
