using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VehicleOwnerController :ControllerBase
    {
        IVehicleOwnerService _vehicleOwnerService;
        public VehicleOwnerController(IVehicleOwnerService vehicleOwnerService)
        {
            _vehicleOwnerService = vehicleOwnerService;
        }

        [HttpPost("[action]")]
        public IActionResult AddReq(VehicleOwner vehicleOwner)
        {
            var result= _vehicleOwnerService.Add(vehicleOwner);
            if (result.Result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByTc(string tc)
        {
            var result = _vehicleOwnerService.GetbyTc(tc);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByPhone(string phone)
        {
            var result = _vehicleOwnerService.GetbyPhone(phone);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _vehicleOwnerService.GetbyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _vehicleOwnerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
