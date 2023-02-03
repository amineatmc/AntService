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
    public interface IDriverRequestService
    {
        Task<IResult> Add(DriverRequest entity);
        IDataResult<DriverRequest> GetbyId(int id);
        IDataResult<List<DriverRequest>> GetbyRequestId(string id);
        IDataResult<DriverRequest> Update(DriverRequestUpdateDto entity);
    }
}
