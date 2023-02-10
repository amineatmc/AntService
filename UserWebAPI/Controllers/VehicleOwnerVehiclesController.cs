using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VehicleOwnerVehiclesController :ControllerBase
    {
        IVehicleOwnerVehicleService _vehicleOwnerVehicleService;
        public VehicleOwnerVehiclesController(IVehicleOwnerVehicleService vehicleOwnerVehicleService)
        {
            _vehicleOwnerVehicleService = vehicleOwnerVehicleService;
        }


        [HttpPost("[action]")]
        public IActionResult Add(VehicleOwnerVehicle entity)
        {
            var result= _vehicleOwnerVehicleService.Add(entity);
            if (result.Result.Success)
            {
                return Ok("Kayıt Eklendi");
            }
            return BadRequest();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id)
        {
            var result = _vehicleOwnerVehicleService.Delete(id);
            if (result.Success)
            {
                return Ok("Kayıt Silindi");
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _vehicleOwnerVehicleService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByVehicleId(int id)
        {
            var result = _vehicleOwnerVehicleService.GetByVehicleId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByVehicleOwnerId(int id)
        {
            var result = _vehicleOwnerVehicleService.GetByVehicleOwnerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
