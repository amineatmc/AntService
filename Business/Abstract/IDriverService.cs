using AntalyaTaksiAccount.Models;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
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
        IDataResult<List<Driver>> GetAll();
        IDataResult<List<Driver>> GetByTc(string tc);
        IDataResult<List<Driver>> GetById(int id);
        
    }
}
