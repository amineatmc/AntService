using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUser : EfEntityRepositoryBase<User, AntTaksiContextDb>, IUser
    {
        public List<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetListByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
