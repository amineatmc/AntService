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
    public class CancelTextManager : ICancelTextService
    {
        ICancelTextDal _cancelTextDal;
        public CancelTextManager(ICancelTextDal cancelTextDal)
        {
            _cancelTextDal = cancelTextDal;
        }

        public IResult Add(CancelText cancelText)
        {
            _cancelTextDal.Add(cancelText);
            return new SuccessResult();
        }

        public IDataResult<List<CancelText>> GetAll()
        {
            return new SuccessDataResult<List<CancelText>>(_cancelTextDal.GetList().ToList());
        }
    }
}
