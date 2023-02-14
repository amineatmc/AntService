using AntalyaTaksiAccount.Models;
using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DriverManager : IDriverService
    {
        IDriverDal _driverDal;
        public DriverManager(IDriverDal driverDal)
        {
            _driverDal= driverDal;
        }     

        public IDataResult<List<DriverListDto>> GetAlls()
        {
            return new SuccessDataResult<List<DriverListDto>>(_driverDal.GetDrivers().Where(x=>x.Activity==1).ToList());
        }

        public IDataResult<List<DriverListDto>> GetById(int id)
        {
            return new SuccessDataResult<List<DriverListDto>>(_driverDal.GetDrivers().Where(x=>x.DriverID == id && x.Activity == 1).ToList());
        }

        public IDataResult<List<DriverListDto>> GetByTc(string tc)
        {
            return new SuccessDataResult<List<DriverListDto>>(_driverDal.GetDrivers().Where(x=>x.IdNo==tc && x.Activity==1).ToList());
        }

        public IDataResult<List<DriverUpdateDto>> Update(DriverUpdateDto driver)
        {
            var drv = _driverDal.Get(x => x.DriverID == driver.DriverID);
            if (drv!=null)
            {
                //if (string.IsNullOrWhiteSpace(driver.IdNo)==false)
                     drv.IdNo = driver.IdNo;
              //  if(string.IsNullOrWhiteSpace(driver.DriverLicenseNo)==false)
                    drv.DriverLicenseNo= driver.DriverLicenseNo;              
                    drv.Rating= driver.Rating;               
                    drv.BirthDay = driver.BirthDay;                
                    drv.Pet = driver.Pet;

                _driverDal.Update(drv);
            }
            return new SuccessDataResult<List<DriverUpdateDto>>();

        }
    }
}
