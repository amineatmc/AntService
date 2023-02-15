using Core.Utilities.Result.Abstract;
using Entities.Dtos;


namespace Business.Abstract
{
    public interface IDriverService
    {
        //Task<IResult> Add(Driver entity);
        //IDataResult<List<Driver>> GetAll();
        IDataResult<List<DriverListDto>> GetByTc(string tc);
        IDataResult<List<DriverListDto>> GetById(int id);
        IDataResult<List<DriverUpdateDto>> Update(DriverUpdateDto driver);
        IDataResult<List<DriverListDto>> GetAlls();
    }
}
