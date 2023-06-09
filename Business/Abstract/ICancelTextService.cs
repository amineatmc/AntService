﻿using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICancelTextService
    {
        IResult Add(CancelText cancelText);
        IDataResult<List<CancelText>> GetAll();
    }
}
