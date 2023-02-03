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
    public interface IStationRequestService
    {
        Task<IResult> Add(StationRequest entity);
        IDataResult<StationRequest> GetbyId(int id);
        IDataResult<StationRequest> Update(StationRequestUpdateDto entity);

    }
}
