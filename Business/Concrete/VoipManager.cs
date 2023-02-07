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
    public class VoipManager : IVoipService
    {
        IVoipDal _voipDal;
        public VoipManager(IVoipDal voipDal)
        {
            _voipDal = voipDal;
        }

        public async Task<IResult> Add(Voip entity)
        {
            _voipDal.Add(entity);
             return new SuccessResult();
        }

        public IDataResult<List<Voip>> GetAll()
        {
            return new SuccessDataResult<List<Voip>>(_voipDal.GetList().ToList());
        }
    }
}
