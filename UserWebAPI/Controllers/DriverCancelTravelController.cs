using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DriverCancelTravelController :ControllerBase
    {
        IDriverCancelTravelService _service;
        public DriverCancelTravelController(IDriverCancelTravelService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public IActionResult Add(DriverCancelTravel driverCancelTravel)
        {
            var result = _service.Add(driverCancelTravel);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();    
        }

        [HttpGet("[action]")]
        public IActionResult GetByDriverId(int id)
        {
            var result = _service.GetByDriverId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
