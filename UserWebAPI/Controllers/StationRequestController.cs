using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationRequestController :ControllerBase
    {
        IStationRequestService _stationRequestService;
        public StationRequestController(IStationRequestService stationRequestService)
        {
            _stationRequestService= stationRequestService;
        }

        [HttpPost("[action]")]
        public IActionResult AddReq(StationRequest entity)
        {
            var history = _stationRequestService.Add(entity);
            if (!history.Result.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpGet("[action]")]
        public IActionResult GetReq(int id)
        {
            var station = _stationRequestService.GetbyId(id);
            if (!station.Success)
            {
                return BadRequest();
            }
            return Ok(station);
        }
    }
}
