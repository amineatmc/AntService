using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Business.Concrete
{
    public class PermitImageManager : IPermitImageService
    {
        IPermitImageDal _permitImage;

       // IVehicleService _vehicleService;
        public PermitImageManager(IPermitImageDal permitImage/*,IVehicleService vehicleService*/)
        {
            _permitImage = permitImage;
           // _vehicleService= vehicleService;
        }

        public Core.Utilities.Result.Abstract.IResult Add(PermitImage entity)
        {
            _permitImage.Add(entity);            
            return new SuccessResult();
        }

        public IDataResult<List<PermitImage>> GetListByImg(string img)
        {
            return new SuccessDataResult<List<PermitImage>>(_permitImage.GetList().Where(x => x.Path == img && x.IsDeleted == false).ToList());
        }

        public IDataResult<List<PermitImage>> GetListByVehicleId(int VehicleId)
        {          
            return new SuccessDataResult<List<PermitImage>>(_permitImage.GetList().Where(x => x.VehicleId == VehicleId && x.IsDeleted == false).ToList());
        }
    
    }
}
