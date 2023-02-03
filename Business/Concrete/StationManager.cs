using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StationManager : IStationService
    {
        public IDataResult<List<Station>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
