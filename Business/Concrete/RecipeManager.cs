using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Server.IISIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RecipeManager : IRecipeService
    {
        IRecipeDal _recipeDal;
        public RecipeManager(IRecipeDal recipeDal)
        {
            _recipeDal = recipeDal;
        }

        public IResult Add(Recipe entity)
        {
            entity.CreatedDate= DateTime.Now;
            entity.IsDeleted = false;
            _recipeDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var entity = _recipeDal.Get(x=>x.RecipeID== id);
            if (entity== null)
            {
                return new ErrorResult();
            }
            entity.IsDeleted = true;
            return new SuccessResult("Kayıt Silindi.");
        }

        public IDataResult<List<Recipe>> GetAll()
        {
            return new SuccessDataResult<List<Recipe>>(_recipeDal.GetList().Where(x=>x.IsDeleted==false).ToList());
        }

        public IDataResult<List<Recipe>> GetById(int id)
        {
            return new SuccessDataResult<List<Recipe>>(_recipeDal.GetList().Where(x => x.RecipeID==id && x.IsDeleted == false).ToList());

        }

        public IDataResult<List<Recipe>> Update(Recipe recipe)
        {
            var entity = _recipeDal.Get(x=>x.RecipeID== recipe.RecipeID);
            if (entity==null)
            {
                return new ErrorDataResult<List<Recipe>>();
            }
            if (string.IsNullOrEmpty(recipe.Region) == false)                
                entity.Region= recipe.Region;
            if (recipe.AçılışÜcreti.ToString() != "0")
                entity.AçılışÜcreti = recipe.AçılışÜcreti;
            if (recipe.İndiBindi.ToString() != "0")
                entity.İndiBindi = recipe.İndiBindi;
            if (recipe.YuzMetrelikMesafeU.ToString() != "0")
                entity.YuzMetrelikMesafeU = recipe.YuzMetrelikMesafeU;
            if (recipe.BirDakikaBeklemeU.ToString() != "0")
                entity.BirDakikaBeklemeU = recipe.BirDakikaBeklemeU;

            _recipeDal.Update(entity);
            return new SuccessDataResult<List<Recipe>>();
        }
    }
}
