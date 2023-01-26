using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BoundaryManager : IBoundaryService
    {
        IBoundaryDal _boundrayDal;
        public BoundaryManager(IBoundaryDal boundaryDal)
        {
            _boundrayDal= boundaryDal;
        }

        public IResult Add(Boundary boundary)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Boundary>> GetAll()
        {
            return new SuccessDataResult<List<Boundary>>(_boundrayDal.GetList());
        }

        public IDataResult<Boundary> GetByStationId(int id)
        {
            var result = _boundrayDal.Get(x=>x.StationId==id);
            if (result!=null)
            {
                return new SuccessDataResult<Boundary>(result);
            }
            return new ErrorDataResult<Boundary>();
        }
    }
}
