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
    public class PaymentTypeManager : IPaymentTypeService
    {
        IPaymentTypeDal _paymentTypeDal;
        public PaymentTypeManager(IPaymentTypeDal paymentTypeDal)
        {
            _paymentTypeDal = paymentTypeDal;
        }

        public async Task<IResult> Add(PaymentType entity)
        {
            if (entity != null)
            {
                _paymentTypeDal.Add(entity);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<PaymentType> GetbyId(int id)
        {
            var result = _paymentTypeDal.Get(x => x.PaymentTypeID == id && x.Status==true);
            return new SuccessDataResult<PaymentType>(result);
        }
    }
}
