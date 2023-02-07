using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        IStationService _stationService;
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }


        [HttpGet("[action]")]
        public IActionResult GetList()
        {
            var result= _stationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("[action]")]
        public IActionResult GetByStationId(int id)
        {
            var result = _stationService.GetByStationId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
