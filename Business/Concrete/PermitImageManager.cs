using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PermitImageManager : IPermitImageService
    {
        IPermitImageDal _permitImage;
        public PermitImageManager(IPermitImageDal permitImage)
        {
            _permitImage = permitImage;
        }

        public Core.Utilities.Result.Abstract.IResult Add(PermitImage entity)
        {
            _permitImage.Add(entity);
            return new SuccessResult();
        }

        public IDataResult<List<PermitImage>> GetListByVehicleId(int VehicleId)
        {
            return new SuccessDataResult<List<PermitImage>>(_permitImage.GetList().Where(x=>x.VehicleId==VehicleId).ToList());
        }

        public IDataResult<List<VehiclePermitImageDto>> GetListVehiclePermitImage(int VehicleId)
        {
            return new SuccessDataResult<List<VehiclePermitImageDto>>(_permitImage.GetVehiclePermitImageList().Where(x=>x.VehicleId==VehicleId).ToList());
        }
    }
}
