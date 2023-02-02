using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAllUser : EfEntityRepositoryBase<AllUser, AntTaksiContextDb>, IAllUser
    {
        public List<OperationClaim> GetClaims(AllUser user)
        {
            throw new NotImplementedException();
        }

        public List<AllUser> GetListByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
