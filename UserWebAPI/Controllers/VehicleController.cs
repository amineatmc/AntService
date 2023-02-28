using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
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

        [HttpPost("[action]")]
        public IActionResult AddVehicle([FromForm]VehicleAddDto vehicle)
        {
            var result = _vehicleService.AddVehicle(vehicle);
            if (result.Success)
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

        [HttpPut("[action]")]
        public IActionResult Update(VehicleUpdateDto vehicleUpdateDto)
        {
            var result = _vehicleService.Update(vehicleUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id)
        {
            var result = _vehicleService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
