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
    public interface IChatService
    {
        Task<IResult> Add(Chat entity);
        IDataResult<List<Chat>> GetByRequestId(string id);

    }
}
