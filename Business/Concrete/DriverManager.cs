using AntalyaTaksiAccount.Models;
using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IDataResult<List<Driver>> GetAll()
        {
            return new SuccessDataResult<List<Driver>>(_driverDal.GetList());
        }

        public IDataResult<List<Driver>> GetById(int id)
        {
            return new SuccessDataResult<List<Driver>>(_driverDal.GetList().Where(x=>x.DriverID==id).ToList());
        }

        public IDataResult<List<Driver>> GetByTc(string tc)
        {
            return new SuccessDataResult<List<Driver>>(_driverDal.GetList().Where(x=>x.IdNo==tc).ToList());
        }
    }
}
