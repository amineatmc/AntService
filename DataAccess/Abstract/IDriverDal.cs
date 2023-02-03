using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using AntalyaTaksiAccount.Models;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IDriverDal: IEntityRepository<Driver>
    {
        List<DriverListDto> GetDrivers();
       // List<DriverUpdateDto> GetUpdateDriver();

    }
}
