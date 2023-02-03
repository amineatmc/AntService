using Business.Abstract;
using Business.Aspects;
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
            boundary.CreatedDate = DateTime.Now;
            _boundrayDal.Add(boundary);
            return new SuccessResult();
        }


       // [SecuredOperation("1")]
        public IDataResult<List<Boundary>> GetAll()
        {
            return new SuccessDataResult<List<Boundary>>(_boundrayDal.GetList());
        }

        public IDataResult<Boundary> GetByStationId(int id)
        {
            var result = _boundrayDal.Get(x=>x.StationID==id);
            if (result!=null)
            {
                return new SuccessDataResult<Boundary>(result);
            }
            return new ErrorDataResult<Boundary>();
        }
    }
}
