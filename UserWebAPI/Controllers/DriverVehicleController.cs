using AntalyaTaksiAccount.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DriverVehicleController : ControllerBase
    {
        IDriverVehicleService _driverVehicleService;
        public DriverVehicleController(IDriverVehicleService driverVehicleService)
        {
            _driverVehicleService = driverVehicleService;
        }


        [HttpPost("[action]")]
        public IActionResult AddReq(DriverVehicle entity)
        {
            var history = _driverVehicleService.Add(entity);
            if (!history.Result.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }


        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var entity = _driverVehicleService.GetAll();
            if (!entity.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpGet("[action]")]
        public IActionResult GetByDriverId(int id)
        {
            var entity = _driverVehicleService.GetByDriverId(id);
            if (!entity.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpGet("[action]")]
        public IActionResult GetByVehicleId(int id)
        {
            var entity = _driverVehicleService.GetByVehicleId(id);
            if (!entity.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }
    }
}
