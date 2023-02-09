using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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
                entity.IsDeleted= false;
                entity.CreatedDate= DateTime.Now;
                _vehicleOwnerDal.Add(entity);
                return new SuccessResult();
            }
            return new ErrorResult("Tc No Kayıtlı!");
        }

        public IResult Delete(int id)
        {
            var result=_vehicleOwnerDal.Get(x=>x.VehicleOwnerID==id && x.IsDeleted==false);
            if (result==null)
            {
                return new ErrorResult();
            }
            result.IsDeleted=true;
            _vehicleOwnerDal.Update(result);
            return new SuccessResult("Kayıt Silindi");
        }

        public IDataResult<List<VehicleOwner>> GetAll()
        {
            return new SuccessDataResult<List<VehicleOwner>>(_vehicleOwnerDal.GetList().Where(x=>x.IsDeleted==false).ToList());
        }

        public IDataResult<VehicleOwner> GetbyId(int id)
        {
            return new SuccessDataResult<VehicleOwner>(_vehicleOwnerDal.Get(x=>x.VehicleOwnerID==id && x.IsDeleted==false));
        }

        public IDataResult<VehicleOwner> GetbyPhone(string phone)
        {
            return new SuccessDataResult<VehicleOwner>(_vehicleOwnerDal.Get(x => x.Phone == phone && x.IsDeleted == false));

        }

        public IDataResult<VehicleOwner> GetbyTc(string tc)
        {
            return new SuccessDataResult<VehicleOwner>(_vehicleOwnerDal.Get(x => x.TCNo == tc && x.IsDeleted == false));

        }

        public IResult Update(VehicleOwnerUpdateDto entity)
        {
            var result= _vehicleOwnerDal.Get(x=>x.VehicleOwnerID== entity.VehicleOwnerID && x.IsDeleted==false);
            if (result!=null)
            {
                if (string.IsNullOrWhiteSpace(entity.Name) == false)
                    result.Name = entity.Name;
                if (string.IsNullOrWhiteSpace(entity.Surname) == false)
                    result.Surname = entity.Surname;
                if (string.IsNullOrWhiteSpace(entity.Phone) == false)
                result.Phone = entity.Phone;
                if (string.IsNullOrWhiteSpace(entity.Mail) == false)
                    result.Mail = entity.Mail;
                if (string.IsNullOrWhiteSpace(entity.TCNo) == false)
                    result.TCNo = entity.TCNo;
                if (string.IsNullOrWhiteSpace(entity.Birthday) == false)
                    result.Birthday = entity.Birthday;

                _vehicleOwnerDal.Update(result);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
