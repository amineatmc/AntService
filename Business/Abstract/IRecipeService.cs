using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRecipeService
    {
        IResult Add(Recipe entity);
        IDataResult<List<Recipe>> GetById(int id);
        IDataResult<List<Recipe>> GetAll();
        IDataResult<List<Recipe>> Update(Recipe recipe);
        IResult Delete(int id);
    }
}
