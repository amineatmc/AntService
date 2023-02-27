using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController  : ControllerBase
    {
        IRecipeService _recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpPost("[action]")]
        public IActionResult Add(Recipe recipe)
        {
            var result = _recipeService.Add(recipe);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _recipeService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _recipeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("[action]")]
        public IActionResult Update(Recipe recipe)
        {
            var result = _recipeService.Update(recipe);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
