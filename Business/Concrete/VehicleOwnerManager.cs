using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VehicleOwnerManager : IVehicleOwnerService
    {
        IVehicleOwnerDal _vehicleOwnerDal;
        public VehicleOwnerManager(IVehicleOwnerDal vehicleOwnerDal)
        {
            _vehicleOwnerDal = vehicleOwnerDal;
        }

        public async Task<IResult> Add(VehicleOwner entity)
        {
            var tc = _vehicleOwnerDal.Get(x=>x.TCNo==entity.TCNo);
            if (tc==null) {
                _vehicleOwnerDal.Add(entity);
                return new SuccessResult();
            }
            return new ErrorResult("Tc No Kayıtlı!");
        }

        public IDataResult<List<VehicleOwner>> GetAll()
        {
            return new SuccessDataResult<List<VehicleOwner>>(_vehicleOwnerDal.GetList());
        }

        public IDataResult<VehicleOwner> GetbyId(int id)
        {
            return new SuccessDataResult<VehicleOwner>(_vehicleOwnerDal.Get(x=>x.VehicleOwnerID==id));
        }

        public IDataResult<VehicleOwner> GetbyPhone(string phone)
        {
            return new SuccessDataResult<VehicleOwner>(_vehicleOwnerDal.Get(x => x.Phone == phone));

        }

        public IDataResult<VehicleOwner> GetbyTc(string tc)
        {
            return new SuccessDataResult<VehicleOwner>(_vehicleOwnerDal.Get(x => x.TCNo == tc));

        }
    }
}
