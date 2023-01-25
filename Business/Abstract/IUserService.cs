using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
    
        IDataResult<List<User>> GetList(int id);
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetUserPhone(string phone);
        IDataResult<User> GetbyId(int id);
        IDataResult<List<User>> GetAll();
    }
}
