using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancelTextController :ControllerBase
    {
        ICancelTextService _cancelTextService;
        public CancelTextController(ICancelTextService cancelTextService)
        {
            _cancelTextService = cancelTextService;
        }

        [HttpPost("[action]")]
        public IActionResult Add(CancelText cancelText)
        {
            var result = _cancelTextService.Add(cancelText);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _cancelTextService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
