using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermitImageController:ControllerBase
    {
        IPermitImageService _permitImageService;
        public PermitImageController(IPermitImageService permitImageService)
        {
            _permitImageService = permitImageService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByVehicleId(int id)
        {
            var result = _permitImageService.GetListVehiclePermitImage(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
