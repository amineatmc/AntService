using AntalyaTaksiAccount.Models;
using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDriverVehicleService
    {
        Task<IResult> Add(DriverVehicle entity);

    }
}
