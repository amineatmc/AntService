using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        IScoreService _scoreService;
        public ScoreController(IScoreService scoreService)
        {
            _scoreService= scoreService;
        }

        [HttpPost("[action]")]
        public IActionResult Add(Score entity)
        {
            var result = _scoreService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByDriverId(int id)
        {
            var result = _scoreService.GetByDriverId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
