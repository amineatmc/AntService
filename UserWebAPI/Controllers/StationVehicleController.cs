using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StationVehicleController:ControllerBase
    {
        IStationVehicleService _stationVehicleService;
        public StationVehicleController(IStationVehicleService stationVehicleService)
        {
            _stationVehicleService = stationVehicleService;
        }

        [HttpPost("[action]")]
        public IActionResult Add(StationVehicle entity)
        {
            var result = _stationVehicleService.Add(entity);
            if (result.Result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _stationVehicleService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _stationVehicleService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByStationId(int id)
        {
            var result = _stationVehicleService.GetByStationId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByVehicleId(int id)
        {
            var result = _stationVehicleService.GetByVehicleId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
