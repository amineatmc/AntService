using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAllUser : IEntityRepository<AllUser>
    {
        List<OperationClaim> GetClaims(AllUser user);

        List<AllUser> GetListByUserId(int id);
    }
}
