using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController :ControllerBase
    {
        IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        [HttpPost("[action]")]
        public IActionResult Add(Vehicle vehicle)
        {
            var result= _vehicleService.Add(vehicle);
            if (result.Result.Success)
            {
                return Ok(vehicle);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _vehicleService.GetbyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _vehicleService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
