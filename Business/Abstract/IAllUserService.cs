using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IAllUserService
    {
    
        IDataResult<List<AllUser>> GetList(int id);
        List<OperationClaim> GetClaims(AllUser user);
      // void Add(AllUser user);

       //Task<IResult> Add(AllUser entity);

        AllUser GetUserPhone(string phone);
        IDataResult<List<AllUser>> GetbyId(int id);
        IDataResult<List<AllUser>> GetAll();
    }
}
