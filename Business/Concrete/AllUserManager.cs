using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.IoC;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AllUserManager : IAllUserService
    {
        private readonly IAllUser _userDal;
        public AllUserManager(IAllUser userDal)
        {
            _userDal= userDal;
        }       

        public IDataResult<List<AllUser>> GetAll()
        {
            return new SuccessDataResult<List<AllUser>>(_userDal.GetList());
        }

        public IDataResult<List<AllUser>> GetbyId(int id)
        {
            return new SuccessDataResult<List<AllUser>>(_userDal.GetList().Where(x => x.AllUserID == id).ToList());
        }

        public List<OperationClaim> GetClaims(AllUser user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<AllUser>> GetList(int id)
        {
            throw new NotImplementedException();
        }

        public AllUser GetUserPhone(string phone)
        {
            throw new NotImplementedException();
        }
    }
}
