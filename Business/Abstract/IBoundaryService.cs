using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBoundaryService
    {
        IDataResult<List<Boundary>> GetAll();
        IDataResult<Boundary> GetByStationId(int id);
        IResult Add(Boundary boundary);
    }
}
