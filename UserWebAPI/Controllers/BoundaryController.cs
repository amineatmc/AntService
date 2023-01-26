using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoundaryController : ControllerBase
    {
        IBoundaryService _boundaryService;
        public BoundaryController(IBoundaryService boundaryService)
        {
            _boundaryService= boundaryService;  
        }

        [HttpGet("[action]")]
        public IActionResult GetAll() 
        {
            var result = _boundaryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _boundaryService.GetByStationId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
