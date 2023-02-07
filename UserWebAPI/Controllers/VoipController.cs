using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoipController: ControllerBase
    {
        IVoipService _voipService;
        public VoipController(IVoipService voipService)
        {
           _voipService = voipService;
        }


        [HttpPost("[action]")]
        public IActionResult Add(Voip voip)
        {
             var result= _voipService.Add(voip);
            if (result.Result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _voipService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
