using AntalyaTaksiAccount.Models;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDriverService
    {
        //Task<IResult> Add(Driver entity);
        //IDataResult<List<Driver>> GetAll();
        IDataResult<List<DriverListDto>> GetByTc(string tc);
        IDataResult<List<DriverListDto>> GetById(int id);
        IDataResult<List<DriverUpdateDto>> Update(DriverUpdateDto driver);
        IDataResult<List<DriverListDto>> GetAlls();
        IResult Add(Driver driver);
    }
}
