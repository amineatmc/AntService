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
    public interface IStationService
    {
        IDataResult<List<StationListDto>> GetAll();
        IDataResult<List<StationListDto>> GetByStationId(int id);
    }
}
