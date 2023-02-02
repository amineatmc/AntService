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

        public async Task<IResult> Add(AllUser entity)
        {
            //entity.CreatedDate= DateTime.Now;
            //entity.UserType = 1;
            _userDal.Add(entity);
            return new SuccessResult();
        }

        public IDataResult<List<AllUser>> GetAll()
        {
            return new SuccessDataResult<List<AllUser>>(_userDal.GetList());
        }

        public IDataResult<AllUser> GetbyId(int id)
        {
            throw new NotImplementedException();
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
